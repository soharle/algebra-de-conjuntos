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
        public List<ElementWithValue> Codomain { get; set; }

        public Classification(List<PairElement> pairList, List<ElementWithValue> domain, List<ElementWithValue> codomain)
        {
            PairList = pairList;
            Domain = domain;
            Codomain = codomain;
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
            for (int i = 0; i < Codomain.Count; i++)
            {
                int repeatedCounter = 0;

                for (int j = 0; j < PairList.Count; j++)
                {
                    if (Codomain[i].Value == PairList[j].Codomain.Value)
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
