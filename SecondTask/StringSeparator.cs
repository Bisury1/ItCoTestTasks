using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SecondExercise
{
    public class StringSeparator
    {
        public string[] SplitString(string inputStr, char separator)
        {
            var resultMas = new string[CaclulateArraySize(inputStr, separator)];
            var indexOfBeginWord = 0;
            for (int i = 0, index = 0; i < inputStr.Length; i++)
            {
                if (inputStr[i].Equals(separator))
                {
                    resultMas[index++] = inputStr.Substring(indexOfBeginWord, i - indexOfBeginWord);
                    indexOfBeginWord = i + 1;
                }
                else if(i == inputStr.Length - 1)
                {
                    resultMas[index++] = inputStr.Substring(indexOfBeginWord, i - indexOfBeginWord + 1);
                }
            }
            return resultMas;
        }
        private int CaclulateArraySize(string inputStr, char separator) => inputStr.Count(character => character.Equals(separator)) + 1;
    }
}
