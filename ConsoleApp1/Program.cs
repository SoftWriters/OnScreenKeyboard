using ClassLibrary1;
using System;
using System.Diagnostics;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.WriteLine("Reading input file from the application package");
            string[] lines = System.IO.File.ReadAllLines(@"input.txt");
            foreach (String line in lines)
            {
                Console.WriteLine("parsing " + line);
                Generator generator = new Generator();
                String output = generator.generate(line);
                Console.WriteLine(output);
            }
        }
    }
}
