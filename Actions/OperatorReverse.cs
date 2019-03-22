using algebra_de_conjuntos.Models;
using System;
using System.Text.RegularExpressions;

namespace algebra_de_conjuntos.Actions
{
    class OperatorReverse
    {
        public static Set ReversivelProdutoDasPartes(Set a)
        {
            string name = a.Name.Substring(a.Name.IndexOf('('), (a.Name.IndexOf(')')));
            name = Regex.Replace(name, @"\(|\)", "");

            Set newSet = new Set
            {
                Name = name
            };

            string allElements = a.ElementsSetToString();

            string pattern = @"\(|\)|{|}|\s";
            string replacement = "";
            string body;
            body = Regex.Replace(allElements, pattern, replacement);

            string[] elements = body.Split(',');

            for (int i = 0; i < elements.Length; i++)
            {
                if (!elements[i].Equals(""))
                {
                    newSet.AddElement(new Element
                    {
                        Value = elements[i]
                    });
                }
            }
            return newSet;
        }

        public static Tuple<Set, Set> ReversivelProdutoCartesiano(Set a)
        {
            string[] names = a.Name.Split('x');

            Set conjuntoA = new Set
            {
                Name = names[0].Trim()
            };
            Set conjuntoB = new Set
            {
                Name = names[1].Trim()
            };

            for (int i = 0; i < a.ListElements.Count; i++)
            {
                string element = a.ListElements[i].Value;

                string pattern = @"\(|\)";
                string replacement = "";
                string body;
                body = Regex.Replace(element, pattern, replacement);

                string[] elements = body.Split(',');

                conjuntoA.AddElement(new Element
                {
                    Value = elements[0].Trim()
                });
                conjuntoB.AddElement(new Element
                {
                    Value = elements[1].Trim()
                });
            }

            return new Tuple<Set, Set>(conjuntoA, conjuntoB);
        }
    }
}
