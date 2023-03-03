using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ArraySort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rnd = new Random();
            const int maxSizeOfMas = 1_000;
            const int minSizeOfMas = 50;
            for (int i = 0; i < 10; i++)
            {
                var currentMas = new int[rnd.Next(minSizeOfMas, maxSizeOfMas)];
                RandomFillArray(currentMas, 0, 2_000);
                var arrSorter = new ArraySorter(currentMas);
                currentMas = arrSorter.Sort();
                Console.WriteLine(string.Join(" ", currentMas));
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        public static void RandomFillArray(int[] mas, int minValue, int maxValue)
        {
            var rnd = new Random();
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = rnd.Next(minValue, maxValue);
            }
        }
    }
}
