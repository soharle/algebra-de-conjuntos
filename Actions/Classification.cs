using algebra_de_conjuntos.Models;
using System.Collections.Generic;

namespace algebra_de_conjuntos.Actions
{
    class Classification
    {
        public List<PairElement> PairList { get; set; }
        public List<ElementWithValue> Domain { get; set; }
        public List<ElementWithValue> Codomain { get; set; }

        public Classification(SetPair setValue, List<ElementWithValue> domain, List<ElementWithValue> codomain)
        {
            PairList = setValue.ListPair;
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


                if (repeatedCounter > 1 || PairList.Count == 0)
                    return false;
            }

            return true;
        }

        public bool IsInjector()
        {
            for (int i = 0; i < Codomain.Count; i++)
            {
                int repeatedCounter = 0;

                for (int j = 0; j < PairList.Count; j++)
                {
                    if (Codomain[i].Value == PairList[j].Codomain.Value)
                        repeatedCounter++;
                }


                if (repeatedCounter > 1 || PairList.Count == 0)
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

                }
                if (repeatedCounter == 0 || PairList.Count == 0)
                    return false;
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

                }
                if (repeatedCounter == 0 || PairList.Count == 0)
                    return false;

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

        public string AllClassifications()
        {
            string classifications = "";

            if (IsFunctional())
            {
                classifications += "Funcional ";
            }
            if (IsInjector())
            {
                classifications += "Injetora ";
            }
            if (IsTotal())
            {
                classifications += "Total ";
            }
            if (IsOverjet())
            {
                classifications += "Sobrejetora ";
            }
            if (IsMonomorphism())
            {
                classifications += "Monomórfica ";
            }
            if (IsEpimorphism())
            {
                classifications += "Epimórfica ";
            }
            if (IsIsomorphism())
            {
                classifications += "Isomórfica";
            }

            classifications = classifications.Trim();
            return classifications.Replace(" ", ", ");
        }
    }
}
