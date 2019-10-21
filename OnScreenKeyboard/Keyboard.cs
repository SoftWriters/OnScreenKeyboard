using System;

namespace OnScreenKeyboard
{
    /*
        Keyboard class
        Contains keyboard layout and method to locate keys.
    */
    /// <summary>
    /// <c>Keyboard</c> class.
    /// Contains keyboard layout and method to locate keys.
    /// </summary>

    public static class Keyboard
    {
        // keyboard dimensions
        const int nRows = 6;
        const int nCols = 6;

        // keyboard layout
        static char[][] layout = new char[nRows][]
        {
           new char[nCols] {'A', 'B', 'C', 'D', 'E', 'F' },
           new char[nCols] {'G', 'H', 'I', 'J', 'K', 'L' },
           new char[nCols] {'M', 'N', 'O', 'P', 'Q', 'R' },
           new char[nCols] {'S', 'T', 'U', 'V', 'W', 'X' },
           new char[nCols] {'Y', 'Z', '1', '2', '3', '4' },
           new char[nCols] {'5', '6', '7', '8', '9', '0' }
        };

        /// <summary>
        /// Gets the key location from its character.
        /// </summary>
        /// <returns>
        /// A pair of numbers which correspond to the row and column of the key position.
        /// </returns>
        /// <param name = "character" >Key's character.</param>   
        public static (int Row, int Col) GetKeyLocation(char character)
        {
            int Row = -1;
            int Col = -1;

            for (int i = 0; i < nRows; i++)
            {
                if (Array.Exists(layout[i], key => key.Equals(character)))
                {
                    Row = i;
                    Col = Array.FindIndex(layout[i], key => key.Equals(character));
                    break;
                }
            }

            return (Row, Col);
        }
    }
}
