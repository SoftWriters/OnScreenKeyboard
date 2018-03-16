using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using lib = OnScreenKeyboardScripter.Lib;

namespace OnScreenKeyboardScripter.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            if (System.IO.File.Exists("sample.txt"))
            {
                lib.IKeyboard keyboard = lib.Factory.GetKeyboard();
                lib.IScripter scripter = lib.Factory.GetScripter();

                System.IO.File.ReadAllLines("sample.txt")
                    .ToList()
                    .ForEach(line =>
                    {
                        string output = string.Empty;
                        try
                        {
                            output = scripter.GetPath(keyboard, line);
                        }
                        catch (Exception e)
                        {
                            output = string.Format("ERROR - unable to translate input:\n\t'{0}'\n{1}", line, e.Message);
                        }
                        Console.WriteLine(output);
                    });
            }

            Console.Write("Press key to exit");
            Console.ReadKey();
        }
    }
}
