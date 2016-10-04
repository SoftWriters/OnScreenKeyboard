using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using Fetzick.OnScreenKeyboard.OnScreenCommand;

namespace Fetzick.OnScreenKeyboard
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = ConfigurationManager.AppSettings["FilePath"];
            string inputFile = filePath + ConfigurationManager.AppSettings["InFileName"];
            string outputFile = filePath + ConfigurationManager.AppSettings["OutFileName"];
            string logFile = filePath + ConfigurationManager.AppSettings["LogFileName"];

            string outputData = string.Empty;
            string[] commands;

            try
            {
                commands = File.ReadAllLines(inputFile);
            }
            catch (Exception ex)
            {
                Console.WriteLine("FILE NOT FOUND: " + ex.Message);
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
                using (System.IO.StreamWriter log = new System.IO.StreamWriter(logFile))
                {
                    log.WriteLine("FILE NOT FOUND: " + ex.Message);
                }
                return;
            }

            Console.WriteLine("Contents of " + outputFile);

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(outputFile))
            {
                // Display the file contents by using a foreach loop.

                foreach (string command in commands)
                {
                    try
                    {
                        string cmd = string.Empty;

                        if (ConfigurationManager.AppSettings["AllowLowerCase"].ToUpper() == "TRUE")
                        {
                            cmd = command.ToUpper();
                        }
                        outputData = OnScreenCommand.OnScreenCommand.GetCommand(cmd);
                        Console.WriteLine("\t" + command + ": " + outputData);
                        file.WriteLine(outputData);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("ERROR (" + inputFile + "): Line = " + command + " " + ex.Message);
                        file.WriteLine("ERROR: Line = " + command + " " + ex.Message);
                        //using (StreamWriter log = new FileA System.IO.StreamWriter(logFile))
                        //{
                        //    log.WriteLine("ERROR (" + inputFile + "): Line = " + line + " " + ex.Message);
                        //}
                    }

                }

            }

            // Keep the console window open
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
