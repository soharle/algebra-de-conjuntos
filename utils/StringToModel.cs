using algebra_de_conjuntos.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace algebra_de_conjuntos.utils
{
    class StringToModel
    {
        public List<Conjunto> Conjuntos { get; set; }
        public List<Elemento> Elementos { get; set; }

        public StringToModel()
        {
            Conjuntos = new List<Conjunto>();
            Elementos = new List<Elemento>();
        }

        public void Load(List<string> content)
        {
            foreach (string line in content)
            {
                string pattern = @"\s*";
                string replacement = "";
                string newLine;
                newLine = Regex.Replace(line, pattern, replacement);
                if (!newLine.Equals(""))
                {
                    if (newLine.Contains("{"))
                    {
                        Conjuntos.Add(LineToConjunto(newLine));
                    }
                    else
                    {
                        Elementos.Add(LineToElemento(newLine));
                    }
                }

            }
        }

        private Conjunto LineToConjunto(string line)
        {
            string[] lines;
            lines = line.Split('=');

            string nome = lines[0];

            string pattern = @"{|}";
            string replacement = "";
            string corpo;

            corpo = Regex.Replace(lines[1], pattern, replacement);
            string[] elementosDoConjunto = corpo.Split(',');

            Conjunto conjunto = new Conjunto
            {
                Nome = nome
            };

            foreach (string e in elementosDoConjunto)
            {
                Elemento elemento = new Elemento
                {
                    Valor = e
                };

                conjunto.ListaElementos.Add(elemento);
            }

            return conjunto;

        }
        private Elemento LineToElemento(string line)
        {
            string[] lines;
            lines = line.Split('=');

            Elemento elemento = new Elemento
            {
                Nome = lines[0],
                Valor = lines[1]
            };

            return elemento;
        }

    }
}
