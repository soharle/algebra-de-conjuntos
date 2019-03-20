using algebra_de_conjuntos.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace algebra_de_conjuntos.Models
{
    public class Operador
    {

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
            TableauGenerator tg = new TableauGenerator();

            char[][] matriz = tg.GerarMatriz(tamanho);

            for (int i = 0; i < matriz.Length; i++)
            {
                lista.Add(tg.MatrizParaElemento(matriz[i], a));
            }
            conjunto.ListaElementos = lista;

            return conjunto;
        }
        
    }
}
