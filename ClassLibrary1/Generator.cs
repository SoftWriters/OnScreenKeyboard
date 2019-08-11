using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ClassLibrary1
{
    public class Generator
    {
        public Dictionary<char, Letter> values;

        public Generator()
        {
            values = new Dictionary<char, Letter>() {
                {'A', new Letter("A", 0, 5) },
                {'B', new Letter("B", 1, 5) },
                {'C', new Letter("C", 2, 5) },
                {'D', new Letter("D", 3, 5) },
                {'E', new Letter("E", 4, 5) },
                {'F', new Letter("F", 5, 5) },
                 
                {'G', new Letter("G", 0, 4) },
                {'H', new Letter("H", 1, 4) },
                {'I', new Letter("I", 2, 4) },
                {'J', new Letter("J", 3, 4) },
                {'K', new Letter("K", 4, 4) },
                {'L', new Letter("L", 5, 4) },
                 
                {'M', new Letter("M", 0, 3) },
                {'N', new Letter("N", 1, 3) },
                {'O', new Letter("O", 2, 3) },
                {'P', new Letter("P", 3, 3) },
                {'Q', new Letter("Q", 4, 3) },
                {'R', new Letter("R", 5, 3) },
                 
                {'S', new Letter("S", 0, 2) },
                {'T', new Letter("T", 1, 2) },
                {'U', new Letter("U", 2, 2) },
                {'V', new Letter("V", 3, 2) },
                {'W', new Letter("W", 4, 2) },
                {'X', new Letter("X", 5, 2) },
                 
                {'Y', new Letter("Y", 0, 1) },
                {'Z', new Letter("Z", 1, 1) },
                {'1', new Letter("1", 2, 1) },
                {'2', new Letter("2", 3, 1) },
                {'3', new Letter("3", 4, 1) },
                {'4', new Letter("4", 5, 1) },
                 
                {'5', new Letter("5", 0, 0) },
                {'6', new Letter("6", 1, 0) },
                {'7', new Letter("7", 2, 0) },
                {'8', new Letter("8", 3, 0) },
                {'9', new Letter("9", 4, 0) },
                {'0', new Letter("0", 5, 0) },
            };
        }

        public string generate(String title)
        {
            title = title.Trim().ToUpper();
            int currentX = 0;
            int currentY = 5;
            List<char> outputArray = new List<char>();

            foreach(Char c in title.ToCharArray()) {

                if (c == ' ')
                {
                    Debug.WriteLine("Looking for: ' '.");
                    outputArray.Add('S');
                }
                else
                {
                    Debug.WriteLine("Looking for: '" + c + "'.");
                    Letter _letter = values[c];
                    char[] yOffets = getYoffset(_letter, currentY);
                    char[] xOffsets = getXoffset(_letter, currentX);
                    outputArray.AddRange(yOffets);
                    outputArray.AddRange(xOffsets);
                    outputArray.Add('#');

                    currentX = _letter.x;
                    currentY = _letter.y;
                }
            }

            return String.Join(",", outputArray);
        }

        private char[] getXoffset(Letter letter, int currentX)
        {
            if (letter.x < currentX)
            {
                char[] c = new char[currentX - letter.x];
                for (int i = 0; i < currentX - letter.x; i++)
                {
                    c[i] = 'L';
                }
                return c;
            }
            else if (letter.x > currentX)
            {
                char[] c = new char[letter.x - currentX];
                for (int i = 0; i < letter.x - currentX; i++)
                {
                    c[i] = 'R';
                }
                return c;
            }
            else
            {
                // letter.x == currentX
                return new char[0];
            }
        }

        private char[] getYoffset(Letter letter, int currentY)
        {
            if (letter.y < currentY)
            {
                char[] c = new char[currentY - letter.y];
                for (int i = 0; i < currentY - letter.y; i++)
                {
                    c[i] = 'D';
                }
                return c;
            }
            else if (letter.y > currentY)
            {
                char[] c = new char[letter.y - currentY];
                for (int i = 0; i < letter.y - currentY; i++)
                {
                    c[i] = 'U';
                }
                return c;
            }
            else
            {
                // letter.y == currentY
                return new char[0];
            }
        }
    }
}
