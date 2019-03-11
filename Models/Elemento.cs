using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace algebra_de_conjuntos.Models
{
    public class Elemento
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Valor { get; set; }

        public Elemento()
        {
            this.Id = IdGenerator.GenerateId();
        }

        public Elemento(string valor)
        {
            this.Id = IdGenerator.GenerateId();
            this.Valor = valor;
        }
        public Elemento(string nome, string valor)
        {
            this.Id = IdGenerator.GenerateId();
            this.Nome = nome;
            this.Valor = valor;
        }

    }

}
