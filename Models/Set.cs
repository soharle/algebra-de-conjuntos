using System.Collections.Generic;
using System.Linq;

namespace algebra_de_conjuntos.Models
{
    public class Set
    {

        public long Id { get; set; }
        public string Name { get; set; }
        public List<Element> ListElements { get; set; }


        public override string ToString()
        {
            return $"{this.Name} = {this.ElementsSetToString()}";
        }

        public Set(string name, List<Element> elements)
        {
            this.Id = this.Id = IdGenerator.GenerateId();
            this.Name = name;
            this.ListElements = elements;
        }

        public Set(string name)
        {
            this.Id = this.Id = IdGenerator.GenerateId();
            this.Name = name;
            this.ListElements = new List<Element>();
        }

        public Set()
        {
            this.Id = IdGenerator.GenerateId();
            this.ListElements = new List<Element>();
        }

        public Set(List<Element> list)
        {
            this.Id = IdGenerator.GenerateId();
            this.ListElements = list;
        }

        public bool AddElement(Element e)
        {
            for (int i = 0; i < ListElements.Count; i++)
            {
                if (ListElements[i].Value.Equals(e.Value))
                {
                    return false;
                }
            }

            ListElements.Add(e);
            return true;
        }

        public Element GetElement(Element element)
        {
            for (int i = 0; i < ListElements.Count; i++)
            {
                if (ListElements[i].Value.Equals(element.Value))
                {
                    return ListElements[i];
                }
            }
            return null;
        }

        public string ElementsSetToString()
        {
            string newElements = "{";
            int size = ListElements.Count();
            for (int i = 0; i < size; i++)
            {
                newElements += ListElements[i].Value;

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
