using algebra_de_conjuntos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algebra_de_conjuntos.Actions
{
    class Classification
    {
        public List<PairElement> PairList { get; set; }
        public List<ElementWithValue> Domain { get; set; }
        public List<ElementWithValue> Image { get; set; }

        public Classification(List<PairElement> pairList, List<ElementWithValue> domain, List<ElementWithValue> image)
        {
            PairList = pairList;
            Domain = domain;
            Image = image;
        }

        public bool IsFunctional()
        {
            for (int i = 0; i < Domain.Count; i++)
            {
                int repeatedCounter = 0;

                for (int j = 0; j < PairList.Count; j++)
                {
                    if (Domain[i].Value == PairList[j].Domain.Value)
                        repeatedCounter++;
                }


                if (repeatedCounter > 1)
                    return false;
            }

            return true;
        }

        public bool IsInjector()
        {
            for (int i = 0; i < Domain.Count; i++)
            {
                int repeatedCounter = 0;

                for (int j = 0; j < PairList.Count; j++)
                {
                    if (Domain[i].Value == PairList[j].Domain.Value)
                        repeatedCounter++;
                }


                if (repeatedCounter > 1)
                    return false;
            }

            return true;
        }

        public bool IsTotal()
        {
            for (int i = 0; i < Domain.Count; i++)
            {
                int repeatedCounter = 0;

                for (int j = 0; j < PairList.Count; j++)
                {
                    if (Domain[i].Value == PairList[j].Domain.Value)
                        repeatedCounter++;

                    if (repeatedCounter == 0)
                        return false;
                }
            }

            return true;
        }

        public bool IsOverjet()
        {
            for (int i = 0; i < Image.Count; i++)
            {
                int repeatedCounter = 0;

                for (int j = 0; j < PairList.Count; j++)
                {
                    if (Image[i].Value == PairList[j].Image.Value)
                        repeatedCounter++;

                    if (repeatedCounter == 0)
                        return false;
                }
            }

            return true;
        }

        public bool IsMonomorphism()
        {
            return (IsTotal() && IsOverjet());
        }

        public bool IsEpimorphism()
        {
            return (IsFunctional() && IsInjector());
        }

        public bool IsIsomorphism()
        {
            return (IsMonomorphism() && IsEpimorphism());
        }
    }
}
