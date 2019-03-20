using algebra_de_conjuntos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace algebra_de_conjuntos.Actions
{
    class OperatorReverse
    {
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

            for (int i = 0; i < elementos.Length; i++)
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
