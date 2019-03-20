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
        public List<ElementoValorado> Domain { get; set; }
        public List<ElementoValorado> Image { get; set; }

        public List<PairElement> LessThan()
        {
            bool relation(int indexDomain, int indexImage)
            {
                return (Domain[indexDomain].Valor < Image[indexImage].Valor) ? true : false;
            }
            return Operation(relation);
        }

        private List<PairElement> MoreThan()
        {
            bool relation(int indexDomain, int indexImage)
            {
                return (Domain[indexDomain].Valor > Image[indexImage].Valor) ? true : false;
            }
            return Operation(relation);
        }

        public List<PairElement> EqualsValues()
        {
            bool relation(int indexDomain, int indexImage)
            {
                return (Domain[indexDomain].Valor == Image[indexImage].Valor) ? true : false;
            }
            return Operation(relation);
        }
        public List<PairElement> Square()
        {
            bool relation(int indexDomain, int indexImage)
            {
                return (Domain[indexDomain].Valor == Math.Sqrt(Image[indexImage].Valor)) ? true : false;
            }
            return Operation(relation);
        }
        public List<PairElement> SquareRoot()
        {
            bool relation(int indexDomain, int indexImage)
            {
                return (Domain[indexDomain].Valor == Math.Pow(Image[indexImage].Valor, 2)) ? true : false;
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
