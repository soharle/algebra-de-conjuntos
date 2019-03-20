using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algebra_de_conjuntos.Models
{
    static class IdGenerator
    {
        private static long Counter = 1;

        public static long GenerateId()
        {
            long aux = Counter;
            Counter += 1;
            return aux;
        }
    }
}
