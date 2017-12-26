using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Ninject;
using System.Reflection;
using OnScreenKeyboard.Exceptions;

namespace OnScreenKeyboard.ConsoleProgram
{
    class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            try
            {
                // initialize NInject for injecting dependencies (e.g. a keyboard)
                var kernel = new StandardKernel();
                kernel.Load(Assembly.GetExecutingAssembly());

                // if file path was not passed as a program argument, ask the user to select a file
                string selectedFilePath;
                if ((args != null) && (args.Length > 0))
                {
                    selectedFilePath = args[0];
                    if (!File.Exists(selectedFilePath))
                    {
                        Console.WriteLine($"Input file does not exist: {selectedFilePath}");
                        return;
                    }
                }
                else
                {
                    selectedFilePath = SelectInputFile();
                }

                ProcessFile(selectedFilePath, kernel);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"\r\nException caught:\r\n{ex.Message}");
            }
            finally
            {
                // write a prompt so the user will have a chance to read results
                Console.WriteLine("\r\nPress ENTER to continue");
                Console.ReadLine();
            }
        }

        private static string SelectInputFile()
        {
            var filePicker = new OpenFileDialog();
            filePicker.Multiselect = false;
            filePicker.InitialDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            filePicker.Title = "Select input file";
            filePicker.Filter = "Text files|*.txt|All files|*.*";
            filePicker.ShowDialog();
            return filePicker.FileName;
        }

        private static void ProcessFile(string filePath, StandardKernel kernel)
        {
            using (var rdr = File.OpenText(filePath))
            {
                string record;
                while((record = rdr.ReadLine()) != null)
                {
                    // ignore blank lines
                    if (!String.IsNullOrEmpty(record))
                    {
                        // inject a new instance of the keyboard
                        //todo: would it be better to use a single instance of the keyboard, but add a method for resetting cursor to initial position?
                        IKeyboard kb = kernel.Get<IKeyboard>();

                        // process the record
                        Console.WriteLine($"\r\n{record}");
                        string result = Search(record, kb);
                        Console.WriteLine($"{result}");
                    }
                }
            }  // end using rdr
        }

        private static string Search(string searchTerm, IKeyboard kb)
        {
            // do the search in its own try/catch so that an exception on this record does not
            // prevent processing for subsequent records
            try
            {
                return kb.Search(searchTerm);
            }
            catch(LetterNotMappedException ex)
            {
                return $"Search string contains character '{ex.Letter}' that does not map to a keyboard character";
            }
            catch(Exception ex)
            {
                return $"Exception occurred while processing record:\r\n{ex.Message}";
            }
        }

    }  // end class
}  // end namespace
