using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftWritersOSK
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "..\\..\\input.txt";
            Traverse.TraverseFile(file);
            Console.ReadLine();
        }
    }
}
