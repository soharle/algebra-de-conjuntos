using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algebra_de_conjuntos.Models
{
    class PairElement
    {
        public ElementWithValue Domain { get; set; }
        public ElementWithValue Image { get; set; }

        public PairElement(Element domain, Element image)
        {
            Domain = new ElementWithValue(domain);
            Image = new ElementWithValue(image);
        }

        public PairElement(ElementWithValue domain, ElementWithValue image)
        {
            Domain = domain;
            Image = image;
        }

    }
}
