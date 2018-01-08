using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnScreenKey
{
    class Program
    {

        [Flags]
         enum ExitCodes : int
        {
            Success = 0,
            MissingInputFile = 1,
            InvalidFileName = 2,
            UnknownError = 4
        }

        // assumptions: sending output directly to stdout
        // stdout can be grabbed and redirected to output files if necessary on implementation end
        // error messages in stderr
        static void Main(string[] args)
        {

            AbstractDVRLineProcessorFactory lineProcFact = new SimpleDVRLineProcessorFactory();
            AbstractDVRLineProcessor lineProc = lineProcFact.getLineProcessor();
            List<String> fileLines = new List<String>();

            if (args == null || args.Length < 1)
                // when filename is missing, write usage reminder to stderr
            {
                Console.Error.WriteLine("Usage: OnScreenKey (filename) -- specify an input text file");
                Environment.Exit((int)ExitCodes.MissingInputFile);
            }

            // otherwise assume we were provided the input flat file

            string filename = args[0];

            try // and attempt to read it in, letting native error handling pick up on any weirdness
            {
                

                fileLines = new List<String>(File.ReadAllLines(filename));
                
            } catch (FileNotFoundException) // stderr will handle this one common exception
            {
                Console.Error.WriteLine("Unable to read from input file: " + filename);
                Environment.Exit((int)ExitCodes.InvalidFileName);
            } catch (Exception) // otherwise output an unknown error
            {
                Console.Error.WriteLine("An unknown error occurred while reading the file: " + filename);
                Environment.Exit((int)ExitCodes.UnknownError);
            }

            // using native encoding and linebreak calculation, iterate over lines of file
            // each new line its own ouput request
            foreach (String fileLine in fileLines)
            {

                String procLine = lineProc.processLine(fileLine);
                if (!(String.IsNullOrEmpty(procLine)))
                {
                    Console.WriteLine(procLine);
                }

            }

            Environment.Exit((int)ExitCodes.Success);

        }
    }
}
