using algebra_de_conjuntos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algebra_de_conjuntos.Actions
{
    class Relationship
    {
        public List<ElementWithValue> Domain { get; set; }
        public List<ElementWithValue> Image { get; set; }

        public List<PairElement> LessThan()
        {
            bool relation(int indexDomain, int indexImage)
            {
                return (Domain[indexDomain].Value < Image[indexImage].Value) ? true : false;
            }
            return Operation(relation);
        }

        private List<PairElement> MoreThan()
        {
            bool relation(int indexDomain, int indexImage)
            {
                return (Domain[indexDomain].Value > Image[indexImage].Value) ? true : false;
            }
            return Operation(relation);
        }

        public List<PairElement> EqualsValues()
        {
            bool relation(int indexDomain, int indexImage)
            {
                return (Domain[indexDomain].Value == Image[indexImage].Value) ? true : false;
            }
            return Operation(relation);
        }
        public List<PairElement> Square()
        {
            bool relation(int indexDomain, int indexImage)
            {
                return (Domain[indexDomain].Value == Math.Sqrt(Image[indexImage].Value)) ? true : false;
            }
            return Operation(relation);
        }
        public List<PairElement> SquareRoot()
        {
            bool relation(int indexDomain, int indexImage)
            {
                return (Domain[indexDomain].Value == Math.Pow(Image[indexImage].Value, 2)) ? true : false;
            }
            return Operation(relation);
        }

        private List<PairElement> Operation(Func<int, int, bool> relation)
        {
            List<PairElement> pairList = new List<PairElement>();

            for (int i = 0; i < Domain.Count; i++)
            {
                for (int j = 0; j < Image.Count; i++)
                {
                    if (relation(i, j))
                    {
                        pairList.Add(new PairElement(Domain[i], Image[j]));
                    }
                }
            }

            return pairList;
        }
    }
}
