using algebra_de_conjuntos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algebra_de_conjuntos.utils
{
    class TableauGenerator
    {
        public char[][] GerarMatriz(int tamanho)
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

        private string ConverteBinario(int numero, int tamanho)
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

        public Elemento MatrizParaElemento(char[] linha, Conjunto c)
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
    }
}
