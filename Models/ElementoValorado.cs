using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algebra_de_conjuntos.Models
{
    class ElementoValorado
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public long Valor { get; set; }

        public ElementoValorado(Elemento e)
        {
            Id = IdGenerator.GenerateId();
            Nome = e.Nome;
            Valor = Int64.Parse(e.Valor);
        }
    }
}
