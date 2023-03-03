using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var separators = new char[] { ' ', '\t', '\n', '\r' };
            var path = Console.ReadLine();
            var lexemReader = new LexemReader(separators, path);
            var searchFactory = new SearchFactory(lexemReader);
            lexemReader.Read();
            Console.WriteLine("Для выхода введи q");
            string input = "";
            int index = 0;
            while ((input = Console.ReadLine()) != "q")
            {
                var lexemSearcher = searchFactory.GetLexemSearcher(input);
                Console.WriteLine(string.Join("\n\r", lexemSearcher.GetFileNameAndCount()));
                Console.Write("Введите номер: ");
                index = int.Parse(Console.ReadLine()) - 1;
                Console.WriteLine(string.Join(" ", lexemSearcher.GetIndexes(index)));
                Console.WriteLine("Для выхода введи q");
            }
        }
    }
}
