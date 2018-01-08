using System;
using System.IO;
using System.Text;

namespace KeyboardWalker
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get name of file
            Console.Write("Please enter name of file (full path): ");
            string filename = Console.ReadLine();
            Console.WriteLine();

            // Instantiate the FindPath object
            FindPath fp = new FindPath();
            
            try
            {
                // Read each line of the input file
                foreach (string line in File.ReadLines(filename, Encoding.UTF8))
                {
                    // Get the path for the search term
                    string path = fp.GetSearchPath(line);

                    // Print the result to the console
                    if (!String.IsNullOrWhiteSpace(line))
                        Console.WriteLine(line + " - " + path);
                }
            }
            catch (IOException)
            {
                Console.WriteLine("Could not open file!");
            }

            // Wait for user to end the application
            Console.WriteLine();
            Console.Write("Press enter to exit...");
            Console.ReadLine();
        }
    }
}
