using System;
using System.Collections.Generic;

namespace SoftWriters
{
    class OnScreenKeyboard
    {
        private Dictionary<char, int> xPosition;
        private Dictionary<char, int> yPosition;

        public OnScreenKeyboard()
        {
            xPosition = new Dictionary<char, int>();
            xPosition.Add('A', 0);
            xPosition.Add('G', 0);
            xPosition.Add('M', 0);
            xPosition.Add('S', 0);
            xPosition.Add('Y', 0);
            xPosition.Add('5', 0);
            xPosition.Add('B', 1);
            xPosition.Add('H', 1);
            xPosition.Add('N', 1);
            xPosition.Add('T', 1);
            xPosition.Add('Z', 1);
            xPosition.Add('6', 1);
            xPosition.Add('C', 2);
            xPosition.Add('I', 2);
            xPosition.Add('O', 2);
            xPosition.Add('U', 2);
            xPosition.Add('1', 2);
            xPosition.Add('7', 2);
            xPosition.Add('D', 3);
            xPosition.Add('J', 3);
            xPosition.Add('P', 3);
            xPosition.Add('V', 3);
            xPosition.Add('2', 3);
            xPosition.Add('8', 3);
            xPosition.Add('E', 4);
            xPosition.Add('K', 4);
            xPosition.Add('Q', 4);
            xPosition.Add('W', 4);
            xPosition.Add('3', 4);
            xPosition.Add('9', 4);
            xPosition.Add('F', 5);
            xPosition.Add('L', 5);
            xPosition.Add('R', 5);
            xPosition.Add('X', 5);
            xPosition.Add('4', 5);
            xPosition.Add('0', 5);

            yPosition = new Dictionary<char, int>();
            yPosition.Add('A', 0);
            yPosition.Add('B', 0);
            yPosition.Add('C', 0);
            yPosition.Add('D', 0);
            yPosition.Add('E', 0);
            yPosition.Add('F', 0);
            yPosition.Add('G', 1);
            yPosition.Add('H', 1);
            yPosition.Add('I', 1);
            yPosition.Add('J', 1);
            yPosition.Add('K', 1);
            yPosition.Add('L', 1);
            yPosition.Add('M', 2);
            yPosition.Add('N', 2);
            yPosition.Add('O', 2);
            yPosition.Add('P', 2);
            yPosition.Add('Q', 2);
            yPosition.Add('R', 2);
            yPosition.Add('S', 3);
            yPosition.Add('T', 3);
            yPosition.Add('U', 3);
            yPosition.Add('V', 3);
            yPosition.Add('W', 3);
            yPosition.Add('X', 3);
            yPosition.Add('Y', 4);
            yPosition.Add('Z', 4);
            yPosition.Add('1', 4);
            yPosition.Add('2', 4);
            yPosition.Add('3', 4);
            yPosition.Add('4', 4);
            yPosition.Add('5', 5);
            yPosition.Add('6', 5);
            yPosition.Add('7', 5);
            yPosition.Add('8', 5);
            yPosition.Add('9', 5);
            yPosition.Add('0', 5);
        }

        /// <summary>
        /// Creates a dtring of specified number of steps in the specified direction.
        /// </summary>
        /// <param name="steps">Number of steps</param>
        /// <param name="direction">Direction of travel</param>
        /// <returns>String of moves</returns>
        private string AddMoves(int steps, string direction)
        {
            string moves = "";
            for (int i = 0; i < steps; i++)
            {
                moves += direction + ",";
            }
            return moves;
        }

        /// <summary>
        /// Finds a path to each character in the word.
        /// </summary>
        /// <param name="word">The word to find a path for</param>
        /// <returns>String containg a comma seperated list of moves</returns>
        public string FindKeyPath(String word)
        {
            string path = ""; //string to return
            int x = 0; //starting x position
            int y = 0; //starting y position

            //convert our word to all upper case because the x and y position dictionaries expect that
            word = word.ToUpper();

            foreach (char c in word)
            {
                //if something is in the path, add a comma to the end
                //this is so we don't return a path with a comma on the end
                if (path != "")
                {
                    path += ",";
                }

                //if the current character is a space, add that to the path and continue, nothing else to do for this character
                if (c.Equals(' '))
                {
                    path += "S";
                    continue;
                }

                //find the x and y position of the character, put them in variables to make things easier to read
                int newX = xPosition[c];
                int newY = yPosition[c];

                //check if the character is left, right, above, or below or current position, and make those moves
                //if the character is on our current position, no moves are made

                //the character is left of our current position
                if (newX < x)
                {
                    path += AddMoves(x - newX, "L");
                }
                //the character is right of our current position
                else if (newX > x)
                {
                    path += AddMoves(newX - x, "R");
                }
                //the character is above our current position
                if (newY < y)
                {
                    path += AddMoves(y - newY, "U");
                }
                //the character is below our current position
                else if (newY > y)
                {
                    path += AddMoves(newY - y, "D");
                }

                //the cursor is on the correct key, add # to the path to select it
                path += "#";

                //update our current x and y position to the new character
                x = newX;
                y = newY;
            }

            return path;
        }

        /// <summary>
        /// Finds a path for each line in the specified file.
        /// </summary>
        /// <param name="FilePath">Path to file</param>
        /// <returns>Array of paths</returns>
        public string [] FindKeyPaths(String FilePath)
        {
            string[] lines = System.IO.File.ReadAllLines(FilePath);
            string[] paths = new string[lines.Length];
            for(int i=0; i<lines.Length; i++)
            {
                paths[i] = FindKeyPath(lines[i]);
            }
            return paths;
        }

    }
}
