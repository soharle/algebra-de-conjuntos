using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algebra_de_conjuntos.Models
{
    class ElementWithValue
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long Value { get; set; }

        public ElementWithValue(Element e)
        {
            Id = IdGenerator.GenerateId();
            Name = e.Name;
            Value = Int64.Parse(e.Value);
        }
    }
}
