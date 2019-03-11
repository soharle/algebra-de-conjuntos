using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace algebra_de_conjuntos.Models
{
    public class Conjunto
    {

        public long Id { get; set; }
        public string Nome { get; set; }
        public List<Elemento> ListaElementos { get; set; }


        public override string ToString()
        {
            return $"{this.Nome} = {this.ElementosConjuntoToString()}";
        }

        public Conjunto(string nome, List<Elemento> elementos)
        {
            this.Id = this.Id = IdGenerator.GenerateId();
            this.Nome = nome;
            this.ListaElementos = elementos;
        }

        public Conjunto(string nome)
        {
            this.Id = this.Id = IdGenerator.GenerateId();
            this.Nome = nome;
            this.ListaElementos = new List<Elemento>();
        }

        public Conjunto()
        {
            this.Id = IdGenerator.GenerateId();
            this.ListaElementos = new List<Elemento>();
        }

        public Conjunto(List<Elemento> lista)
        {
            this.Id = IdGenerator.GenerateId();
            this.ListaElementos = lista;
        }

        public bool SetElemento(Elemento e)
        {
            for (int i = 0; i < ListaElementos.Count; i++)
            {
                if (ListaElementos[i].Valor.Equals(e.Valor))
                {
                    return false;
                }
            }

            ListaElementos.Add(e);
            return true;
        }

        public Elemento GetElemento(string valor)
        {
            for (int i = 0; i < ListaElementos.Count; i++)
            {
                return ListaElementos[i].Valor.Equals(valor) ? ListaElementos[i] : null;
            }
            return null;
        }

        public Elemento GetElemento(Elemento elemento)
        {
            for (int i = 0; i < ListaElementos.Count; i++)
            {
                if (ListaElementos[i].Valor.Equals(elemento.Valor))
                {
                    return ListaElementos[i];
                }
            }
            return null;
        }

        public string ElementosConjuntoToString()
        {
            string newElementos = "{";
            int tamanho = ListaElementos.Count();
            for (int i = 0; i < tamanho; i++)
            {
                newElementos += ListaElementos[i].Valor;

                if (i < (tamanho - 1))
                {
                    newElementos += ", ";
                }

            }
            newElementos += "}";

            return newElementos;
        }

    }
}
