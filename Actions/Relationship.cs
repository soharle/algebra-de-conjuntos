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
        public List<ElementWithValue> Codomain { get; set; }

        public List<PairElement> LessThan()
        {
            bool relation(int indexDomain, int indexCodomain)
            {
                return (Domain[indexDomain].Value < Codomain[indexCodomain].Value) ? true : false;
            }
            return Operation(relation);
        }

        private List<PairElement> MoreThan()
        {
            bool relation(int indexDomain, int indexCodomain)
            {
                return (Domain[indexDomain].Value > Codomain[indexCodomain].Value) ? true : false;
            }
            return Operation(relation);
        }

        public List<PairElement> EqualsValues()
        {
            bool relation(int indexDomain, int indexCodomain)
            {
                return (Domain[indexDomain].Value == Codomain[indexCodomain].Value) ? true : false;
            }
            return Operation(relation);
        }
        public List<PairElement> Square()
        {
            bool relation(int indexDomain, int indexCodomain)
            {
                return (Domain[indexDomain].Value == Math.Sqrt(Codomain[indexCodomain].Value)) ? true : false;
            }
            return Operation(relation);
        }
        public List<PairElement> SquareRoot()
        {
            bool relation(int indexDomain, int indexCodomain)
            {
                return (Domain[indexDomain].Value == Math.Pow(Codomain[indexCodomain].Value, 2)) ? true : false;
            }
            return Operation(relation);
        }

        private List<PairElement> Operation(Func<int, int, bool> relation)
        {
            List<PairElement> pairList = new List<PairElement>();

            for (int i = 0; i < Domain.Count; i++)
            {
                for (int j = 0; j < Codomain.Count; i++)
                {
                    if (relation(i, j))
                    {
                        pairList.Add(new PairElement(Domain[i], Codomain[j]));
                    }
                }
            }

            return pairList;
        }

        private List<PairElement> ComposedRelationship(List<PairElement> ab, List<PairElement> bc)
        {
            List<PairElement> composed = new List<PairElement>();

            for (int i = 0; i < ab.Count; i++)
            {
                for (int j = 0; j < bc.Count; j++)
                {
                    if(ab[i].Codomain.Value == bc[j].Domain.Value)
                    {
                        PairElement newPair = new PairElement(ab[i].Domain, bc[j].Codomain);

                        int repeatedCounter = 0;
                        for (int k = 0; k < composed.Count && repeatedCounter == 0; k++)
                        {
                            if (composed[k].Equal(newPair))
                                repeatedCounter++;
                        }

                        if(repeatedCounter == 0)
                            composed.Add(newPair);
                    }
                }
            }

            return composed;
        }
    }
}
