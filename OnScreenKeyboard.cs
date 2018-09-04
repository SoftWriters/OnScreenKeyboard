//OnScreenKeyboard coding test
//Author: Dave Hartman


using System;
using System.IO;

namespace OnScreenKeyboard
{
    class LineProcessor
    {
        static void Main(string[] args)
        {
            string cwd = Directory.GetCurrentDirectory();
            if (args.Length == 0)
            {
                Console.WriteLine("No input file specified");
            }
            else
            {
                if (File.Exists(args[0]))
                {
                    Keyboard keyboard = new Keyboard();
                    string[] allLinesIn = System.IO.File.ReadAllLines(args[0]);

                    foreach (string inputLine in allLinesIn)
                    {
                        keyboard.gotoHomePosition();
                        Console.WriteLine(keyboard.generateKeyboardPath(inputLine));
                    }
                }
                else
                {
                    Console.WriteLine("File specified not found: " + args[0]);
                }
            }
            Console.ReadKey();
        }
    }
}
