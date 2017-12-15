using System;
using System.Configuration;
using System.IO;
using System.Text;

namespace OnScreenKeyboard
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Please type input file path. Example: c:\\input.txt ");
                Console.ReadKey();
                return;
            }

            string[] inputStrings = readInputFile(args[0]);
            if(inputStrings.Length == 0)
            {
                Console.WriteLine("Input file is empty. Please validate the input file and try again.");
                Console.ReadKey();
                return;
            }

            try
            {

                string typename = ConfigurationManager.AppSettings["ScreenKeyboard"];
                Type type = Type.GetType(typename);

                IScreenKeyboard keyboard = (IScreenKeyboard)Activator.CreateInstance(type);

                foreach (string str in inputStrings)
                {
                    string output = keyboard.StringToKeyboard(str);
                    Console.WriteLine(output);

                    // Validating output by inverse operation
                    Console.WriteLine(keyboard.KeyboardToString(output));
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            Console.ReadKey();
        }

        

        private static string[] readInputFile(string filePath)
        {
            return File.ReadAllLines(filePath, Encoding.UTF8);
        }
    }
}
