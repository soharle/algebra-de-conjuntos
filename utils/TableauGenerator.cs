using algebra_de_conjuntos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algebra_de_conjuntos.utils
{
    class TableauGenerator
    {
        public char[][] GenerateTableau(int size)
        {
            int maxValue = (int)Math.Pow(2, size);
            char[][] tableau = new char[maxValue][];

            for (int i = 0; i < maxValue; i++)
            {
                string binaries = ConvertBinary(i, size);
                tableau[i] = binaries.ToCharArray();
            }

            return tableau;
        }

        private string ConvertBinary(int number, int size)
        {
            List<int> RemainingList = new List<int>();

            while (number > 0)
            {
                RemainingList.Add(number % 2);
                number = number / 2;
            }

            string value = "";
            for (int i = RemainingList.Count - 1; i >= 0; i--)
            {
                value += RemainingList[i].ToString();
            }

            if (value.Length < size)
            {
                int variation = size - value.Length;
                int count = 0;
                string valueAux = "";

                while (count < variation)
                {
                    valueAux += "0";
                    count++;
                }

                value = valueAux + value;
            }

            return value;
        }

        public Element TableauToElement(char[] row, Set c)
        {
            Set setAux = new Set();
            for (int i = 0; i < row.Length; i++)
            {

                if (row[i].Equals('1'))
                {
                    setAux.AddElement(new Element
                    {
                        Value = c.ListElements[i].Value
                    });
                }
            }

            return new Element
            {
                Value = setAux.ElementsSetToString()
            };

        }
    }
}
