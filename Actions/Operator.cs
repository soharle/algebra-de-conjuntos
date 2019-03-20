using algebra_de_conjuntos.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace algebra_de_conjuntos.Models
{
    public class Operator
    {

        public static bool Belongs(Element element, Set set)
        {
            return !(set.GetElement(element) == null);
        }

        public static bool Contain(Set a, Set b)
        {

            for (int i = 0; i < a.ListElements.Count; i++)
            {
                if (!Operator.Belongs(a.ListElements[i], b))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool ProperlyContain(Set a, Set b)
        {

            for (int i = 0; i < a.ListElements.Count; i++)
            {
                if (!Operator.Belongs(a.ListElements[i], b))
                {
                    return false;
                }
            }

            for (int i = 0; i < b.ListElements.Count; i++)
            {
                if (!Operator.Belongs(b.ListElements[i], a))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool Contains(Set a, Set b)
        {
            return Operator.Contain(b, a);
        }

        public static bool Igual(Set a, Set b)
        {
            if (Operator.Contain(a, b) &&
                Operator.Contain(b, a))
            {
                return true;
            }
            return false;
        }

        public static Set Union(Set a, Set b)
        {
            Set set = new Set
            {
                Name = a.Name + " U " + b.Name
            };

            for (int i = 0; i < a.ListElements.Count; i++)
            {
                set.AddElement(a.ListElements[i]);
            }
            for (int i = 0; i < b.ListElements.Count; i++)
            {
                set.AddElement(b.ListElements[i]);
            }

            return set;
        }

        public static Set Intersection(Set a, Set b)
        {
            Set set = new Set
            {
                Name = a.Name + " ∩ " + b.Name
            };

            for (int i = 0; i < a.ListElements.Count; i++)
            {
                if (Operator.Belongs(a.ListElements[i], b))
                {
                    set.AddElement(a.ListElements[i]);
                }
            }

            return set;
        }

        public static Set CartesianProduct(Set a, Set b)
        {
            Set conjunto = new Set
            {
                Name = a.Name + " x " + b.Name
            };

            for (int i = 0; i < a.ListElements.Count; i++)
            {
                for (int j = 0; j < b.ListElements.Count; j++)
                {
                    conjunto.AddElement(new Element { Value = $"({a.ListElements[i].Value}, {b.ListElements[j].Value})" });
                }
            }

            return conjunto;
        }

        public static Set SetOfParts(Set a)
        {
            Set set = new Set
            {
                Name = $"P({a.Name})"
            };

            int size = a.ListElements.Count;

            List<Element> listE = new List<Element>();
            TableauGenerator tg = new TableauGenerator();

            char[][] tableau = tg.GenerateTableau(size);

            for (int i = 0; i < tableau.Length; i++)
            {
                listE.Add(tg.TableauToElement(tableau[i], a));
            }
            set.ListElements = listE;

            return set;
        }
        
    }
}
