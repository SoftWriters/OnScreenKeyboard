using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/* submitted by Michele Dumm for SoftWriters' code challenge  */

namespace OnScreenKeyboardApplication
{

    class Program
    {
        static void Main()
        {
            string testInput = @"c:\OSKBtest\KBtest.txt";  /* file used for input for test unless this line is changed */

            CreateTestFileIfNeeded(testInput);   /* for your ease of testing this will create an input test file if it is not there */

            /* output for this test will go to c:\OSKBtest\KBtestOutPut.txt unless the following line is changed */
            MapCursorMovements(testInput, @"c:\OSKBtest\KBtestOutPut.txt", StandardKeyboard);
        }

        public static void MapCursorMovements(string fileName, string outputFile, Char[,] Keyboard)
        {
            /* This code will script the path of the cursor over the keyboard.
               Keyboard is a parameter to allow for other keyboards in the future.  */

            bool AppendOutput = false;

            if (File.Exists(fileName))
            {
                // Read input text file 
                using (System.IO.StreamReader sr = new System.IO.StreamReader(fileName))
                {
                    String line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        //convert string to array
                        char[] InputArray = line.ToUpper().ToCharArray();

                        StringBuilder CursorPath = new StringBuilder();

                        /* Assume cursor starting at A for each line read from file */
                        int LastVertical = 0;
                        int LastHorizontal = 0;

                        for (int j = 0; j < InputArray.Length; j++)
                        {
                            if (InputArray[j] == ' ')
                            {
                                CursorPath.Append(",S");
                            }
                            else
                            {
                                MatrixCoordinates KB = GetCoordinates(InputArray[j], Keyboard);

                                /*  if there is a possibility of a character not on the keyboard (except for space),
                                add a check here so that if (KB.CurrentVertical == -1) go to error processing  */

                                CursorPath.Append(TraverseKeyboard(LastVertical, KB.CurrentVertical, 'U', 'D'));
                                CursorPath.Append(TraverseKeyboard(LastHorizontal, KB.CurrentHorizontal, 'L', 'R'));

                                LastVertical = KB.CurrentVertical;
                                LastHorizontal = KB.CurrentHorizontal;
                                CursorPath.Append(",#");
                            }
                        }

                        /* writing out one path for the DVR for each input line */
                        /* First write will clear out anything that was already in this file (anything from when this was previously executed) */
                        WriteLineToFile(outputFile, AppendOutput, CursorPath.ToString().TrimStart(','));

                        AppendOutput = true;
                    }
                }
            }  /* may want to add error processing here if input file does not exist */
        }


        public static string TraverseKeyboard(int Last, int Current, char Backward, char Forward)
        {
            StringBuilder result = new StringBuilder();
            int Steps = Math.Abs(Last - Current);
            char Direction = (Current < Last) ? Backward : Forward;

            for (int p = 0; p < Steps; p++)
            {
                result.Append("," + Direction);
            }
            return result.ToString();
        }

        public static MatrixCoordinates GetCoordinates(Char Target, Char[,] Matrix)
        {
            // returns the position of the first occurrence or target character in a two-dimensional array of characters
            MatrixCoordinates result = new MatrixCoordinates();
            result.CurrentVertical = -1;
            result.CurrentHorizontal = -1;
            for (int v = 0; ((v < Matrix.GetLength(0)) && (result.CurrentVertical == -1)); v++)
            {
                for (int h = 0; ((h < Matrix.GetLength(1)) && (result.CurrentHorizontal == -1)); h++)
                {
                    if (Matrix[v, h] == Target)
                    {
                        result.CurrentVertical = v;
                        result.CurrentHorizontal = h;
                        return result;
                    }
                }
            }
            return result;  /* may want error-handling and/or special process either here or later if -1 returned for coordinates */
        }


        public static void WriteLineToFile(String outputFile, bool AppendOutput, String outputLine)
        {
            using (StreamWriter writetext = new StreamWriter(outputFile, AppendOutput))
            {
                writetext.WriteLine(outputLine);
            }
        }

        public static void CreateTestFileIfNeeded(String testInput)
        {
            /* for your ease of testing this will create an input test file if it is not there */
            if (!(File.Exists(testInput)))
            {
                using (StreamWriter writetext = new StreamWriter(testInput))
                {
                    writetext.WriteLine("IT Crowd");
                }
            }
        }

        public class MatrixCoordinates
        {
            public int CurrentHorizontal { get; set; }
            public int CurrentVertical { get; set; }
        }

        public static readonly Char[,] StandardKeyboard = new Char[6, 6]
                   {{'A', 'B', 'C', 'D', 'E', 'F'},
                    {'G', 'H', 'I', 'J', 'K', 'L'},
                    {'M', 'N', 'O', 'P', 'Q', 'R'},
                    {'S', 'T', 'U', 'V', 'W', 'X'},
                    {'Y', 'Z', '1', '2', '3', '4'},
                    {'5', '6', '7', '8', '9', '0'}};
    }

}

