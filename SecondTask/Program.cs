using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var str = "fbmrokfb mdbfrjofbn efmobke emfbekfbo beojr";
            var strSep = new StringSeparator();
            var mas = strSep.SplitString(str, ' ');
            Console.WriteLine(string.Join(" ", mas));
            Console.ReadKey();
        }
    }
}
