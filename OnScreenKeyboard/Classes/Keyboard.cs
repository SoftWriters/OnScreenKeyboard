using System;
using System.IO;
using System.Web;

namespace OnScreenKeyboard.Classes
{
    public class Keyboard
    {
        public readonly char[,] KeyboardLayout = new char[,]
        {
                                        {'A', 'B', 'C', 'D', 'E', 'F'},
                                        {'G', 'H', 'I', 'J', 'K', 'L'},
                                        {'M', 'N', 'O', 'P', 'Q', 'R'},
                                        {'S', 'T', 'U', 'V', 'W', 'X'},
                                        {'Y', 'Z', '1', '2', '3', '4'},
                                        {'5', '6', '7', '8', '9', '0'},
        };
        public string KeyboardPathOutput { get; set; }
        private readonly Tuple<int, int> BadCoordinate = Tuple.Create(-1, -1);

        public Keyboard(HttpPostedFileBase InputFile)
        {
            this.KeyboardPathOutput = "I need a text file with text, pal!";

            // Sniff out empty files or overtly bad file types such as images or music "Content Type" is very limited
            if (GetFileType(InputFile.FileName) == "text/plain" && InputFile != null && InputFile.ContentLength > 0)
            {
                this.KeyboardPathOutput = "";
                PopulateKeyboardPathOutput(InputFile);
            }
        }

        public void PopulateKeyboardPathOutput(HttpPostedFileBase InputFile)
        {
            using (StreamReader sr = new StreamReader(InputFile.InputStream))
            {
                // Loop through every line of the file
                while (sr.Peek() >= 0)
                {
                    char oldCharacter = 'A';
                    string thisLine = sr.ReadLine();

                    // Loop through every character in the line to get a set of directions
                    foreach (char thisCharacter in thisLine.ToUpper())
                    {
                        if (thisCharacter == ' ')
                        {
                            this.KeyboardPathOutput += "S,";
                        }
                        else
                        {
                            try
                            {
                                this.KeyboardPathOutput += GetDirectionBlock(oldCharacter, thisCharacter);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Exception in GetKeyboardPathOutput: " + e.Message);
                            }

                            oldCharacter = thisCharacter;
                        }
                    }

                    // End of the line: Remove the last comman and add a break
                    this.KeyboardPathOutput = this.KeyboardPathOutput.TrimEnd(',') + Environment.NewLine;
                }
            }
        }

        private string GetDirectionBlock(char FromChar, char ToChar)
        {
            string direction = "";

            try
            {
                // Get From and To Coordinates and compare them
                var FromCoordinate = GetCoordinate(FromChar);
                var ToCoordinate = GetCoordinate(ToChar);

                // Check if all the characters are actually on the keyboard. If it's a bad character, we return the empty string.
                if (FromCoordinate != BadCoordinate && ToCoordinate != BadCoordinate)
                {
                    int vertical = FromCoordinate.Item1 - ToCoordinate.Item1;
                    int horizontal = FromCoordinate.Item2 - ToCoordinate.Item2;

                    // Get vertifcal moves and assign to direction
                    if (vertical > 0)
                    {
                        direction = GetNumberOfMoves(vertical, "U");
                    }
                    else
                    {
                        direction = GetNumberOfMoves(vertical, "D");
                    }

                    // Get the horizontal moves and append to direction
                    if (horizontal > 0)
                    {
                        direction += GetNumberOfMoves(horizontal, "L");
                    }
                    else
                    {
                        direction += GetNumberOfMoves(horizontal, "R");
                    }

                    // Append the select key and comma
                    return direction + "#,";
                }
                else
                {
                    // Expect an empty string return for a bad character
                    return direction;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in GetDirectionBlock: " + e.Message);
                return string.Empty;
            }
        }

        private Tuple<int, int> GetCoordinate(char thisChar)
        {
            // Loop through the keyboard to find the character coordinate
            for (int x = 0; x < 6; x++)
            {
                for (int y = 0; y < 6; y++)
                {
                    if (KeyboardLayout[x, y].ToString() == thisChar.ToString())
                    {
                        return Tuple.Create(x, y);
                    }
                }
            }

            return BadCoordinate;
        }

        private string GetNumberOfMoves(int NumberOfSpaces, string Direction)
        {
            string moves = "";

            // Loop through the number of times you need to move in the given direction
            for (int m = 0; m < Math.Abs(NumberOfSpaces); m++)
            {
                moves += Direction + ",";
            }

            return moves;
        }

        private string GetFileType(string fileName)
        {
            // Assume "weird" mimeType is a flat file
            string fileType = "text/plain";
            string ext = Path.GetExtension(fileName).ToLower();

            Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);

            if (regKey != null && regKey.GetValue("Content Type") != null)
            {
                fileType = regKey.GetValue("Content Type").ToString();
            }

            return fileType;
        }
    }
}