using System.Collections.Generic;
using System.Linq;

namespace algebra_de_conjuntos.Models
{
    class SetPair
    {
        public long Id { get; set; }
        public List<PairElement> ListPair { get; set; }


        public SetPair()
        {
            Id = IdGenerator.GenerateId();
            ListPair = new List<PairElement>();
        }

        public string ListPairToString()
        {
            string newElements = "{";
            int size = ListPair.Count();
            for (int i = 0; i < size; i++)
            {
                newElements += ListPair[i].ToString();

                if (i < (size - 1))
                {
                    newElements += ", ";
                }

            }
            newElements += "}";

            return newElements;
        }
    }
}
