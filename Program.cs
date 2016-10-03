using System;
using System.IO;
using System.Linq;

namespace TestApplication
{
    class Program
    {
        // ReSharper disable once UnusedParameter.Local
        static void Main(string[] args)
        {
            Console.Write("\n\r Please enter the file name with location:  \n");
                var enteredfileName = Console.ReadLine();
                // to check if the file exists
                var ifFileExists= CheckFileName(enteredfileName);
            if (!ifFileExists)
            {
                Console.Write("\n\r File doesn't exist in the location. Please enter the file name with location:  \n");
                enteredfileName = Console.ReadLine();
            }
                   

            //read the file  line by line
            // ReSharper disable once NotAccessedVariable
                var counter = 0;
                string line;
                var file =
                    // ReSharper disable once AssignNullToNotNullAttribute
                   new StreamReader(enteredfileName);
                while ((line = file.ReadLine()) != null)
                {
                    GetOutputPath(line);
                   // Console.WriteLine(line);
                    counter++;
                }
                Console.Write("\n\r Please press any to Exit :  \n");
                 Console.ReadLine();
            
            
        }

        public static void GetOutputPath(string inputText)
        {
            inputText = inputText.ToUpper();
            char[,] keyboardArray = {
              {'A','B','C','D','E','F'}, 
              {'G','H','I','J','K','L'},
              {'M','N','O','P','Q','R'},
              {'S','T','U','V','W','X'},
              {'Y','Z','1','2','3','4'} ,
              {'5','6','7','8','9','0'} 

            };
            var outputString = "";
            var prevrowval = 0;var prevColval=0;
            var w = keyboardArray.GetLength(0); // width
            var h = keyboardArray.GetLength(1); // height
            foreach(char c in inputText)
            {
                if (c == ' ')
                {
                    outputString += "S";
                }
                else
                {
                    for (var x = 0; x < w; ++x)
                    {
                        for (var y = 0; y < h; ++y)
                        {
                            if (keyboardArray[x, y].Equals(c))
                            {
                                //x is width
                                //y is height
                                var rowvalue = x;
                                var colval = y;
                                // to check if c is first Character of the word.
                                if (outputString == "")
                                {
                                    while (rowvalue > 0)
                                    {
                                        outputString += "D";
                                        rowvalue--;
                                    }
                                    while (colval > 0)
                                    {
                                        outputString += "R";
                                        colval--;
                                    }
                                    outputString += "#";
                                    prevrowval = x;
                                    prevColval = y;
                                }
                                else
                                {
                                    // computing the row difference with respect to the previous Character
                                    var rowdiff = rowvalue - prevrowval;

                                    // computing the col difference with respect to the previous Character
                                    var coldiff =  colval-prevColval;
                                   

                                    if (rowdiff > 0)
                                    {
                                        while (rowdiff > 0)
                                        {
                                            outputString += "D";
                                            rowdiff--;
                                        }

                                    }
                                    else
                                    {
                                        while (rowdiff < 0)
                                        {
                                            outputString += "U";
                                            rowdiff++;
                                        }

                                    }
                                    if (coldiff > 0)
                                    {
                                        while (coldiff > 0)
                                        {
                                            outputString += "R";
                                            coldiff--;
                                        }
                                    }
                                    else
                                    {
                                        while (coldiff < 0)
                                        {
                                            outputString += "L";
                                            coldiff++;
                                        }
                                    }

                                    outputString += "#";
                                    prevrowval = x;
                                    prevColval = y;

                                }


                            }

                        }

                    }
                }

            }
            var finalOutputString = AppendDelimiter(outputString);
            Console.WriteLine("Cursor path for the Keyboard input : " + inputText + " is : " + finalOutputString);


        }

        public static bool CheckFileName(string fullfileName)
        {
            bool fileExists = File.Exists(fullfileName);
            return fileExists;
        }

        public static string AppendDelimiter(string outputString)
        {
            var finalOutputString = "";
            var i = 0;
            foreach (char c in outputString)
            {
                if (i < outputString.Count()-1)
                finalOutputString += c + ",";
                else
                {
                    finalOutputString += c;
                }
                i++;

            }
            return finalOutputString;

        }


    }
}
