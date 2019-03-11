using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace algebra_de_conjuntos.Models
{
    public sealed class Operador
    {
        private static readonly Operador instance = new Operador();

        static Operador()
        {
        }

        private Operador()
        {
        }

        public static Operador Instance
        {
            get
            {
                return instance;
            }
        }


        public static bool Pertence(Elemento elemento, Conjunto conjunto)
        {
            return !(conjunto.GetElemento(elemento) == null);
        }

        public static bool Contido(Conjunto a, Conjunto b)
        {

            for (int i = 0; i < a.ListaElementos.Count; i++)
            {
                if (!Operador.Pertence(a.ListaElementos[i], b))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool ContidoPropriamente(Conjunto a, Conjunto b)
        {

            for (int i = 0; i < a.ListaElementos.Count; i++)
            {
                if (!Operador.Pertence(a.ListaElementos[i], b))
                {
                    return false;
                }
            }

            for (int i = 0; i < b.ListaElementos.Count; i++)
            {
                if (!Operador.Pertence(b.ListaElementos[i], a))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool Contem(Conjunto a, Conjunto b)
        {
            return Operador.Contido(b, a);
        }

        public static bool Igual(Conjunto a, Conjunto b)
        {
            if (Operador.Contido(a, b) &&
                Operador.Contido(b, a))
            {
                return true;
            }
            return false;
        }

        public static Conjunto Uniao(Conjunto a, Conjunto b)
        {
            Conjunto conjunto = new Conjunto
            {
                Nome = a.Nome + " U " + b.Nome
            };

            for (int i = 0; i < a.ListaElementos.Count; i++)
            {
                conjunto.SetElemento(a.ListaElementos[i]);
            }
            for (int i = 0; i < b.ListaElementos.Count; i++)
            {
                conjunto.SetElemento(b.ListaElementos[i]);
            }

            return conjunto;
        }

        public static Conjunto Intersecao(Conjunto a, Conjunto b)
        {
            Conjunto conjunto = new Conjunto
            {
                Nome = a.Nome + " ∩ " + b.Nome
            };

            for (int i = 0; i < a.ListaElementos.Count; i++)
            {
                if (Operador.Pertence(a.ListaElementos[i], b))
                {
                    conjunto.SetElemento(a.ListaElementos[i]);
                }
            }

            return conjunto;
        }

        public static Conjunto ProdutoCartesiano(Conjunto a, Conjunto b)
        {
            Conjunto conjunto = new Conjunto
            {
                Nome = a.Nome + " x " + b.Nome
            };

            for (int i = 0; i < a.ListaElementos.Count; i++)
            {
                for (int j = 0; j < b.ListaElementos.Count; j++)
                {
                    conjunto.SetElemento(new Elemento { Valor = $"({a.ListaElementos[i].Valor}, {b.ListaElementos[j].Valor})" });
                }
            }

            return conjunto;
        }

        public static Conjunto ConjuntoDasPartes(Conjunto a)
        {
            Conjunto conjunto = new Conjunto
            {
                Nome = $"P({a.Nome})"
            };

            int tamanho = a.ListaElementos.Count;

            List<Elemento> lista = new List<Elemento>();

            char[][] matriz = GerarMatriz(tamanho);

            for (int i = 0; i < matriz.Length; i++)
            {
                lista.Add(MatrizParaElemento(matriz[i], a));
            }
            conjunto.ListaElementos = lista;

            return conjunto;
        }

        private static Elemento MatrizParaElemento(char[] linha, Conjunto c)
        {
            Conjunto conjuntoAux = new Conjunto();
            for (int i = 0; i < linha.Length; i++)
            {
                
                if (linha[i].Equals('1'))
                {
                    conjuntoAux.SetElemento(new Elemento
                    {
                        Valor = c.ListaElementos[i].Valor
                    });
                }
            }

            return new Elemento
            {
                Valor = conjuntoAux.ElementosConjuntoToString()
            };

        }

        private static char[][] GerarMatriz(int tamanho)
        {
            int valorMaximo = (int)Math.Pow(2, tamanho);
            char[][] matriz = new char[valorMaximo][];

            for (int i = 0; i < valorMaximo; i++)
            {
                string binario = ConverteBinario(i, tamanho);
                matriz[i] = binario.ToCharArray();
            }

            return matriz;
        }

        private static string ConverteBinario(int numero, int tamanho)
        {
            List<int> listaRestante = new List<int>();

            while (numero > 0)
            {
                listaRestante.Add(numero % 2);
                numero = numero / 2;
            }

            string valor = "";
            for (int i = listaRestante.Count - 1; i >= 0; i--)
            {
                valor += listaRestante[i].ToString();
            }

            if (valor.Length < tamanho)
            {
                int diferenca = tamanho - valor.Length;
                int cont = 0;
                string valorAux = "";

                while (cont < diferenca)
                {
                    valorAux += "0";
                    cont++;
                }

                valor = valorAux + valor;
            }

            return valor;
        }

        public static Conjunto ReversivelProdutoDasPartes(Conjunto a)
        {
            string nome = a.Nome.Substring(a.Nome.IndexOf('('), (a.Nome.IndexOf(')')));
            nome = Regex.Replace(nome, @"\(|\)", "");

            Conjunto novo = new Conjunto
            {
                Nome = nome
            };

            string todosElementos = a.ElementosConjuntoToString();

            string pattern = @"\(|\)|{|}|\s";
            string replacement = "";
            string corpo;
            corpo = Regex.Replace(todosElementos, pattern, replacement);

            string[] elementos = corpo.Split(',');

            for(int i = 0; i < elementos.Length; i++)
            {
                if (!elementos[i].Equals(""))
                {
                    novo.SetElemento(new Elemento
                    {
                        Valor = elementos[i]
                    });
                }
            }
            return novo;
        }

        public static Tuple<Conjunto, Conjunto> ReversivelProdutoCartesiano(Conjunto a)
        {
            string[] nomes = a.Nome.Split('x');

            Conjunto conjuntoA = new Conjunto
            {
                Nome = nomes[0].Trim()
            };
            Conjunto conjuntoB = new Conjunto
            {
                Nome = nomes[1].Trim()
            };

            for (int i = 0; i < a.ListaElementos.Count; i++)
            {
                string elemento = a.ListaElementos[i].Valor;

                string pattern = @"\(|\)";
                string replacement = "";
                string corpo;
                corpo = Regex.Replace(elemento, pattern, replacement);

                string[] elementos = corpo.Split(',');

                conjuntoA.SetElemento(new Elemento
                {
                    Valor = elementos[0].Trim()
                });
                conjuntoB.SetElemento(new Elemento
                {
                    Valor = elementos[1].Trim()
                });
            }

            return new Tuple<Conjunto, Conjunto>(conjuntoA, conjuntoB);
        }
    }
}
