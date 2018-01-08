using System;
using System.Configuration;
using System.IO;

namespace Fetzick.OnScreenKeyboard
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get file names from app config
            string filePath = ConfigurationManager.AppSettings["FilePath"];
            string inputFile = filePath + ConfigurationManager.AppSettings["InFileName"];
            string outputFile = filePath + ConfigurationManager.AppSettings["OutFileName"];
            string logFile = filePath + ConfigurationManager.AppSettings["LogFileName"];

            // Initialize log file
            Fetzick.Utilities.LogFile.LogFile log = new Fetzick.Utilities.LogFile.LogFile(logFile);

            // Store list of commands from input file
            string[] commands;

            // String to store output commands once processed
            string outputData = string.Empty;

            // Try to read input file.  If fails... log error and stop execution
            try
            {
                commands = File.ReadAllLines(inputFile);

            }
            catch (Exception ex)
            {
                Console.WriteLine("FILE NOT FOUND: " + ex.Message);
                log.WriteToLogFile("FILE NOT FOUND: " + ex.Message);

                // Keep the console window open
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
                
                return;
            }

            Console.WriteLine("Contents of " + outputFile);

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(outputFile))
            {
                // Process the file.  If fails... log error and continue to process file 
                foreach (string command in commands)
                {
                    try
                    {
                        string cmd = string.Empty;

                        // Initial requirments didn't mention the use of lower case characters.  But sample ("IT Crowd") had lower case letters.  So I figure that I would make it configurable  
                        if (ConfigurationManager.AppSettings["AllowLowerCase"].ToUpper() == "TRUE")
                        {
                            cmd = command.ToUpper();
                        }

                        // Get the path to the command
                        outputData = OnScreenCommand.OnScreenCommand.GetCommand(cmd);

                        // Write command path to output file
                        Console.WriteLine("\t" + command + ": " + outputData);
                        file.WriteLine(outputData);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("ERROR (" + inputFile + "): Line = " + command + " " + ex.Message);
                        log.WriteToLogFile("ERROR (" + inputFile + "): Line = " + command + " " + ex.Message);

                        // The current output file doesn't have invalid lines written to file.  Uncomment if future requrements change...
                        //file.WriteLine("ERROR (" + inputFile + "): Line = " + command + " " + ex.Message);    
                    }

                }

            }

            // Keep the console window open
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
