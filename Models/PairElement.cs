using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algebra_de_conjuntos.Models
{
    class PairElement
    {
        public ElementoValorado Domain { get; set; }
        public ElementoValorado Image { get; set; }

        public PairElement(Elemento domain, Elemento image)
        {
            Domain = new ElementoValorado(domain);
            Image = new ElementoValorado(image);
        }

        public PairElement(ElementoValorado domain, ElementoValorado image)
        {
            Domain = domain;
            Image = image;
        }

    }
}
