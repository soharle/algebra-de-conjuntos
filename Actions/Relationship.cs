using algebra_de_conjuntos.Models;
using System;
using System.Collections.Generic;

namespace algebra_de_conjuntos.Actions
{
    class Relationship
    {
        public string Name { get; set; }
        public List<ElementWithValue> Domain { get; set; }
        public List<ElementWithValue> Codomain { get; set; }
        private SetPair LastOperation { get; set; }

        public SetPair LessThan()
        {
            bool relation(int indexDomain, int indexCodomain)
            {
                return (Domain[indexDomain].Value < Codomain[indexCodomain].Value) ? true : false;
            }
            return Operation(relation);
        }

        public SetPair GreaterThan()
        {
            bool relation(int indexDomain, int indexCodomain)
            {
                return (Domain[indexDomain].Value > Codomain[indexCodomain].Value) ? true : false;
            }
            return Operation(relation);
        }

        public SetPair EqualsValues()
        {
            bool relation(int indexDomain, int indexCodomain)
            {
                return (Domain[indexDomain].Value == Codomain[indexCodomain].Value) ? true : false;
            }
            return Operation(relation);
        }
        public SetPair Square()
        {
            bool relation(int indexDomain, int indexCodomain)
            {
                return (Domain[indexDomain].Value == Math.Pow(Codomain[indexCodomain].Value, 2)) ? true : false;
            }
            return Operation(relation);
        }
        public SetPair SquareRoot()
        {
            bool relation(int indexDomain, int indexCodomain)
            {
                return (Domain[indexDomain].Value == Math.Sqrt(Codomain[indexCodomain].Value)) ? true : false;
            }
            return Operation(relation);
        }

        private SetPair Operation(Func<int, int, bool> relation)
        {
            SetPair set = new SetPair();
            

            for (int i = 0; i < Domain.Count; i++)
            {
                for (int j = 0; j < Codomain.Count; j++)
                {
                    if (relation(i, j))
                    {
                        set.ListPair.Add(new PairElement(Domain[i], Codomain[j]));
                    }
                }
            }
            LastOperation = set;
            return set;
        }

        public SetPair ComposedRelationship(SetPair ab, SetPair bc)
        {
            SetPair composed = new SetPair();

            for (int i = 0; i < ab.ListPair.Count; i++)
            {
                for (int j = 0; j < bc.ListPair.Count; j++)
                {
                    if(ab.ListPair[i].Codomain.Value == bc.ListPair[j].Domain.Value)
                    {
                        PairElement newPair = new PairElement(ab.ListPair[i].Domain, bc.ListPair[j].Codomain);

                        int repeatedCounter = 0;
                        for (int k = 0; k < composed.ListPair.Count && repeatedCounter == 0; k++)
                        {
                            if (composed.ListPair[k].Equal(newPair))
                                repeatedCounter++;
                        }

                        if(repeatedCounter == 0)
                            composed.ListPair.Add(newPair);
                    }
                }
            }

            LastOperation = composed;
            return composed;
        }

        public string AllClassifications()
        {
            Classification classification = new Classification(LastOperation, Domain, Codomain);
            return classification.AllClassifications();
        }
    }
}
