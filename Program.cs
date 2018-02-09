using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NewProjectCC
{
    /// Thinking of a large system, I'd like to save all the output from one key to the other to a hashtable. This will save the time complexity since we don't need to 
    /// process any logic from key to key but only get value from hashtable.
    /// If the size of the input file is big, and we have enough resource, I believe we can do a divide and conquer to read different lines from the input file and process it at the same time.
    /// I didn't implement devide and conquer today. But do please let me know if you'd like me to implement it that way. Thank you so much!
    class Program
    {
        //Keyboard characters except space
        const string KeyBoard = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        //Hashtable which stores the preprocessed output from key to another key on the keyboard
        public static Hashtable keyToKeyMatrix;

        static void Main(string[] args)
        {
            //Generate the hashtable from pre-process to get the output key from one key to another on the keyboard
            PreProcess();
            //Get input search term by line
            var input = ParseArgument();
            //For each line of the search term, process the result, and write it down to the console.
            if (input != null)
            {
                Console.WriteLine("The output is: ");
                Console.WriteLine("---");
                foreach (var r in GetResult(input))
                {
                    //If it's the message for invalid input, don't add comma between each character.
                    if (r.Contains("Invalid input detected in this term"))
                        Console.WriteLine(r);
                    else
                        Console.WriteLine(string.Join(",", r.ToCharArray()));
                }
            }
            //To keep console open until press a key
            Console.WriteLine("---");
            Console.WriteLine("Press any key to close this window...");
            Console.Read();
        }

        /// <summary>
        /// Get result by matching the characters read from the input file and write the path to the console
        /// </summary>
        /// <param name="input">A string list, each line contains a sarch term (one line from input file)</param>
        /// <returns>string array for the path output</returns>
        private static string[] GetResult(List<string> input)
        {
            var result = new string[input.Count];
            int resultIndex = 0;
            //Read by term
            foreach (var line in input)
            {
                var output = string.Empty;
                //If the line is empty, there's no output.
                if (!string.IsNullOrEmpty(line))
                {
                    //Define start point A
                    var preChar = 'A';
                    for (int i = 0; i < line.Length; i++)
                    {
                        //If the input character is not valid (not in the keyboard)
                        if (!(line[i].Equals(' ') || KeyBoard.Contains(line[i])))
                        {
                            output = (string.Format("Invalid input detected in this term: {0}", line[i]));
                            break;
                        }

                        //Get the correct output path from current character and previous character
                        if (line[i].Equals(' '))
                            output += "S";
                        else if (line[i].Equals(preChar))
                            output += "#";
                        else
                        {
                            var index = string.Format("{0}{1}", preChar, line[i]);
                            output += keyToKeyMatrix[index].ToString();
                            preChar = line[i];
                        }
                    }
                }
                //Add the output per line to the result string array.
                result[resultIndex++] = output;
            }

            return result;
        }

        /// <summary>
        /// Parse argument, read file name from console, and read the file
        /// </summary>
        /// <returns>String list by reading file by line.</returns>
        private static List<string> ParseArgument()
        {
            var inputPerLine = new List<string>();
            var line = string.Empty;

            //Read file name
            Console.WriteLine("Please specify your input file below: ");
            try
            {
                var inputFileName = Console.ReadLine();
                if (inputFileName != null)
                {
                    //Read file using streamreader
                    StreamReader file = new StreamReader(inputFileName);
                    //Read line
                    while ((line = file.ReadLine()) != null)
                    {
                        inputPerLine.Add(line);
                    }
                }
            }
            catch (Exception)
            {
                //Catch exception while reading file, write it to console
                Console.WriteLine("Error occurred during reading the file, please try again.");
                return null;
            }

            //If the input file is empty, return a console message.
            if (inputPerLine.Count == 0)
            {
                Console.WriteLine("Empty input file detected.");
                return null;
            }

            return inputPerLine;
        }

        /// <summary>
        /// This preprocess will generate a hashtable and write this hashtable to a file, so this doesn't need to be run unless the file is missing.
        /// For each element in this hashtable, the key is currentKey to NextKey when these two keys are different. For example, "AB" means from A to B on the given keyboard; 
        ///                                     the value is the path through the onscreen keyboard (output). For example, the value for "AB" is "R#"
        /// </summary>
        /// <returns>Hashtable with path from one key to the other</returns>
        private static Hashtable PreProcess()
        {
            keyToKeyMatrix = new Hashtable();

            //Convert the keyboard string to ASCII chars
            var charsASCII = Encoding.ASCII.GetBytes(KeyBoard.ToCharArray());

            //Process the ASCII char array, so that A is 0, and every other cahracter is the distance to A, including 1-0 which shows on the onscreen keyboard too.
            for (int n = 0; n < charsASCII.Length; n++)
            {
                //This handles number 0
                if (n == charsASCII.Length - 1)
                    charsASCII[n] -= 13;  //ASCII for 0 = 48, in the keyboard string, 0's index is 35. So 48-35=13
                //This handles number 1-9
                else if (n >= charsASCII.Length - 10)
                    charsASCII[n] -= 23; //ASCII for 1 = 49, in the keyboard string, 1's index is 26. So 49-26=23
                else
                    charsASCII[n] -= 65; //ASCII for A = 65
            }

            //These loops calcultes the real path from one key to another from the oncreen keyboard, and add the key and the value to the hashtable
            for (int i = 0; i < charsASCII.Length; i++)
            {
                //Since the paths are always opposite between one key to another, only loop the the ones after charsASCII[i] is enough
                for (int j = i + 1; j < charsASCII.Length; j++)
                {
                    var outputPattern = string.Empty;
                    var outputPatternReverse = string.Empty;

                    //Think the onscreen keyboard as a matrix with x and y coordinate, the position for the two keys are presents as in positioni and positionj
                    var positioni = new KeyValuePair<int, int>(charsASCII[i] % 6, charsASCII[i] / 6);
                    var positionj = new KeyValuePair<int, int>(charsASCII[j] % 6, charsASCII[j] / 6);

                    //Get the horizonal distance
                    var horizonalDistance = positionj.Key - positioni.Key;
                    //If the distance is greater than 0, then from key i to key j, we need to move right, and from key j to key i , we need to move left. Vise Versa.
                    for (int a = 0; a < Math.Abs(horizonalDistance); a++)
                    {
                        outputPattern += "L";
                        outputPatternReverse += "R";
                    }
                    if (horizonalDistance > 0)
                    {
                        var temp = outputPattern;
                        outputPattern = outputPatternReverse;
                        outputPatternReverse = temp;
                    }

                    //Since key j is always after key i , the vertical distance is always greater or equal than 0
                    for (int b = 0; b < (positionj.Value - positioni.Value); b++)
                    {
                        outputPattern += "D";
                        outputPatternReverse += "U";
                    }

                    //Get char from the keyboard string
                    var chars = KeyBoard.ToCharArray();

                    //Add "<characterFrom><characterTo>" as key, the path with selected key # as value
                    keyToKeyMatrix.Add(string.Format("{0}{1}", chars[i], chars[j]), string.Format("{0}#", outputPattern));
                    keyToKeyMatrix.Add(string.Format("{0}{1}", chars[j], chars[i]), string.Format("{0}#", outputPatternReverse));
                }
            }
            return keyToKeyMatrix;
        }
    }
}
