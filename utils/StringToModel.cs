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
        public List<Set> Sets { get; set; }
        public List<Element> Elements { get; set; }

        public StringToModel()
        {
            Sets = new List<Set>();
            Elements = new List<Element>();
        }

        public void Load(List<string> content)
        {
            foreach (string line in content)
            {
                string pattern = @"\s*";
                string replacement = "";
                string newRow;
                newRow = Regex.Replace(line, pattern, replacement);
                if (!newRow.Equals(""))
                {
                    if (newRow.Contains("{"))
                    {
                        Sets.Add(RowToSet(newRow));
                    }
                    else
                    {
                        Elements.Add(RowToElement(newRow));
                    }
                }

            }
        }

        private Set RowToSet(string row)
        {
            string[] rows;
            rows = row.Split('=');

            string name = rows[0];

            string pattern = @"{|}";
            string replacement = "";
            string body;

            body = Regex.Replace(rows[1], pattern, replacement);
            string[] elementsOfSet = body.Split(',');

            Set set = new Set
            {
                Name = name
            };

            foreach (string e in elementsOfSet)
            {
                Element element = new Element
                {
                    Value = e
                };

                set.ListElements.Add(element);
            }

            return set;

        }
        private Element RowToElement(string row)
        {
            string[] rows;
            rows = row.Split('=');

            Element element = new Element
            {
                Name = rows[0],
                Value = rows[1]
            };

            return element;
        }

    }
}
