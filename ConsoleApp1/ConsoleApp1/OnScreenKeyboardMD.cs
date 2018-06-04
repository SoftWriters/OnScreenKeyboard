using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class OnSreenKeyboard
    {
        /* Author          Comment                         Date
         * Mark Dinkel     Created Visual C# 2017        5/28/2018
         * 
         * Purpose: Translate input text string into arrow key-presses on a matrix keyboard
         *          
         */

        //Create Key Map X-Y coordinate hashtables
        static private Hashtable keyMapX = new Hashtable();
        static private Hashtable keyMapY = new Hashtable();

        static private void OnScreenKeyboard()
        {
            // class initializer 
            // Add elements to the key map hash tables - X and Y coordinates 
            // The Start is the letter A at (1,1) is the number 0 at (6,6)
            keyMapX.Add("A", "1"); keyMapY.Add("A", "1");
            keyMapX.Add("B", "2"); keyMapY.Add("B", "1");
            keyMapX.Add("C", "3"); keyMapY.Add("C", "1");
            keyMapX.Add("D", "4"); keyMapY.Add("D", "1");
            keyMapX.Add("E", "5"); keyMapY.Add("E", "1");
            keyMapX.Add("F", "6"); keyMapY.Add("F", "1");
            keyMapX.Add("G", "1"); keyMapY.Add("G", "2");
            keyMapX.Add("H", "2"); keyMapY.Add("H", "2");
            keyMapX.Add("I", "3"); keyMapY.Add("I", "2");
            keyMapX.Add("J", "4"); keyMapY.Add("J", "2");
            keyMapX.Add("K", "5"); keyMapY.Add("K", "2");
            keyMapX.Add("L", "6"); keyMapY.Add("L", "2");
            keyMapX.Add("M", "1"); keyMapY.Add("M", "3");
            keyMapX.Add("N", "2"); keyMapY.Add("N", "3");
            keyMapX.Add("O", "3"); keyMapY.Add("O", "3");
            keyMapX.Add("P", "4"); keyMapY.Add("P", "3");
            keyMapX.Add("Q", "5"); keyMapY.Add("Q", "3");
            keyMapX.Add("R", "6"); keyMapY.Add("R", "3");
            keyMapX.Add("S", "1"); keyMapY.Add("S", "4");
            keyMapX.Add("T", "2"); keyMapY.Add("T", "4");
            keyMapX.Add("U", "3"); keyMapY.Add("U", "4");
            keyMapX.Add("V", "4"); keyMapY.Add("V", "4");
            keyMapX.Add("W", "5"); keyMapY.Add("W", "4");
            keyMapX.Add("X", "6"); keyMapY.Add("X", "4");
            keyMapX.Add("Y", "1"); keyMapY.Add("Y", "5");
            keyMapX.Add("Z", "2"); keyMapY.Add("Z", "5");
            keyMapX.Add("1", "3"); keyMapY.Add("1", "5");
            keyMapX.Add("2", "4"); keyMapY.Add("2", "5");
            keyMapX.Add("3", "5"); keyMapY.Add("3", "5");
            keyMapX.Add("4", "6"); keyMapY.Add("4", "5");
            keyMapX.Add("5", "1"); keyMapY.Add("5", "6");
            keyMapX.Add("6", "2"); keyMapY.Add("6", "6");
            keyMapX.Add("7", "3"); keyMapY.Add("7", "6");
            keyMapX.Add("8", "4"); keyMapY.Add("8", "6");
            keyMapX.Add("9", "5"); keyMapY.Add("9", "6");
            keyMapX.Add("0", "6"); keyMapY.Add("0", "6");

        }

        private static string XYToKeys(int currX, int currY, int nextX, int nextY)
        {
            // Private method to translate the arrow key presses from the current key to 
            // the next key using (U)p, (D)own, (L)eft and (R)ight
            int moveX, moveY, strPos = 0;
            char[] keys = new char[512];

            moveX = nextX - currX;
            moveY = nextY - currY;

            if (moveY > 0)
            {
                for (int i = 0; i < moveY; i++)
                {
                    keys[strPos++] = 'D';
                    keys[strPos++] = ',';
                }
            }
            else
            {
                for (int i = 0; i > moveY; i--)
                {
                    keys[strPos++] = 'U';
                    keys[strPos++] = ',';
                }
            }
            if (moveX > 0)
            {
                for (int i=0;i<moveX;i++)
                {
                    keys[strPos++] = 'R';
                    keys[strPos++] = ',';
                }
            }
            else
            {
                for (int i = 0; i > moveX; i--)
                {
                    keys[strPos++] = 'L';
                    keys[strPos++] = ',';
                }
            }
           
            keys[strPos++] = '#';
            keys[strPos++] = ',';

            String retStr = new String(keys);

            return retStr;

        }

        static void Main(string[] args)
        {
            string currKey = "A", currStr = "", upStr;
            int currX = 1, currY = 1, nextX, nextY;

            object objNextX, objNextY;
            string nextKey;
            
            string keyDirections;
            string allKeyDirections = "";

            // class initializer
            OnScreenKeyboard();

            // This can be updated to any filestream
            string inFile = @"C:\Users\mark\Documents\Data\inData.txt";
            try
            {
                using (FileStream fsRead = new FileStream(inFile, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader srRead = new StreamReader(fsRead))
                    {
                        // This can be updated to any file stream
                        string outFile = @"C:\Users\mark\Documents\Data\outData.txt";
                        using (FileStream fsWrite = new FileStream(outFile, FileMode.OpenOrCreate, FileAccess.Write))
                        {
                            using (StreamWriter srWrite = new StreamWriter(fsWrite))
                            {

                                while (!srRead.EndOfStream)
                                {
                                    currStr = srRead.ReadLine();
                                    upStr = currStr.ToUpper();

                                    // Reset to the starting key position
                                    currKey = "A"; currX = 1; currY = 1;

                                    foreach (char c in upStr)
                                    {
                                        if (!char.IsWhiteSpace(c))
                                        {
                                            nextKey = c.ToString(); // The char for the key-press
                                            objNextX = keyMapX[nextKey]; // X coordinate of the char
                                            objNextY = keyMapY[nextKey]; // Y coordinate of the char

                                            // X-Y location of the key-press
                                            nextX = int.Parse(string.Format("{0}", objNextX));
                                            nextY = int.Parse(string.Format("{0}", objNextY));

                                            // Get the key-presses from the current char to the next char
                                            keyDirections = XYToKeys(currX, currY, nextX, nextY);
                                            allKeyDirections += keyDirections; // add to final string

                                            // Update the current char to the next char
                                            currKey = c.ToString();
                                            currX = nextX;
                                            currY = nextY;
                                        }
                                        else
                                        {
                                            allKeyDirections += "S,"; // (S)pace

                                        }

                                    }
                                    // Replace nul characters in the final string and write
                                    allKeyDirections = allKeyDirections.Replace(Convert.ToChar(0x0).ToString(), "");
                                    // Remove the last comma added to the final string
                                    allKeyDirections = allKeyDirections.Remove(allKeyDirections.Length - 1);
                                    // Add a newline after each line that is written to the output file
                                    allKeyDirections += Environment.NewLine;
                                }
                                srWrite.Write(allKeyDirections);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Execute the application using Ctrl+F5 to see the exception messages
                Console.WriteLine(ex.Message);
            }

        }


        }


}
