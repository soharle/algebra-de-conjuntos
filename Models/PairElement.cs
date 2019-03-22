
namespace algebra_de_conjuntos.Models
{
    class PairElement
    {
        public ElementWithValue Domain { get; set; }
        public ElementWithValue Codomain { get; set; }

        public PairElement(Element domain, Element codomain)
        {
            Domain = new ElementWithValue(domain);
            Codomain = new ElementWithValue(codomain);
        }

        public PairElement(ElementWithValue domain, ElementWithValue codomain)
        {
            Domain = domain;
            Codomain = codomain;
        }

        public bool Equal(PairElement pairElement)
        {
            return (pairElement.Domain.Value == Domain.Value && pairElement.Codomain.Value == Codomain.Value) ? true : false;
        }

        public override string ToString()
        {
            return $"({Domain.Value}, {Codomain.Value})";
        }
    }
}
