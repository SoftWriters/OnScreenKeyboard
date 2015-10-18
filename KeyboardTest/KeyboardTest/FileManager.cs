using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KeyboardTest
{
    static class FileManager
    {
        /// <summary>
        /// Static method that accepts the input file name to generate an output file name and accepts the string to append to the file
        /// </summary>
        /// <param name="inputFileName"></param>
        /// <param name="stringToAppend"></param>
        public static void WriteStringToFile(string inputFileName, string stringToAppend)
        {
            string outputFileName = CreateOutputFileName(inputFileName);
            stringToAppend += stringToAppend + System.Environment.NewLine;
            File.AppendAllText(outputFileName, stringToAppend);
        }

        /// <summary>
        /// Static method that accepts the user selected input file name to generate an output file name
        /// in the same directory with the original name + output
        /// </summary>
        /// <param name="inputFileName"></param>
        /// <returns></returns>
        public static string CreateOutputFileName(string inputFileName)
        {
            string fileName = Path.GetFileNameWithoutExtension(inputFileName);
            string dir = Path.GetDirectoryName(inputFileName);

            string outputFileName = dir + @"\" + fileName + "Output.txt";
            return outputFileName;
        }
    }
}
