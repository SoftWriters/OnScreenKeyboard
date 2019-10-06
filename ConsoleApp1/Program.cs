using ConsoleApp1.files;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ProgramMethods pm = new ProgramMethods();
            Keyboard keyboard = new Keyboard();
            var path = @"C:\Users\Raizel Seliger\source\repos\ConsoleApp1\.vs\ConsoleApp1\v16\text.txt";

            Console.WriteLine(pm.Output(path, keyboard));
            Console.ReadKey();
        }
    }
}
