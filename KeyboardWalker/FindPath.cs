using System;

namespace KeyboardWalker
{
    public class FindPath
    {
        #region Public Structs
        public struct Coordinate
        {
            public int? X;
            public int? Y;

            public Coordinate(int x, int y)
            {
                X = x;
                Y = y;
            }

            public override bool Equals(object obj)
            {
                bool ret = false;

                if (obj is Coordinate)
                {
                    Coordinate c = (Coordinate)obj;
                    ret = ((X == c.X) && (Y == c.Y));
                }

                return ret;
            }
        }
        #endregion

        #region Private Class Members
        private char[][] _keyboardLayout = new char[6][]
        {
            new char[6] {'A', 'B', 'C', 'D', 'E', 'F' },
            new char[6] {'G', 'H', 'I', 'J', 'K', 'L' },
            new char[6] {'M', 'N', 'O', 'P', 'Q', 'R' },
            new char[6] {'S', 'T', 'U', 'V', 'W', 'X' },
            new char[6] {'Y', 'Z', '1', '2', '3', '4' },
            new char[6] {'5', '6', '7', '8', '9', '0' }
        };
        #endregion

        #region Getters & Setters
        public char[][] GetKeyboardLayout()
        {
            return _keyboardLayout;
        }

        public void SetKeyboardLayout(char[][] keyboardLayout)
        {
            _keyboardLayout = keyboardLayout;
        }
        #endregion

        #region Constructor
        public FindPath(char[][] keyboardLayout = null)
        {
            // Check to see if a new keyboard layout was given
            if (keyboardLayout != null)
            {
                _keyboardLayout = keyboardLayout;
            }
        }
        #endregion

        #region Public Methods
        // Get the full path of a string search term
        public string GetSearchPath(string searchTerm)
        {
            string path = "";
            char curr = 'A';
            int counter = 0;

            // Iterate through each character in the search term
            foreach (char c in searchTerm)
            {
                // Find the pattern from current letter
                path += GetCharacterPath(curr, c);

                // Append a comma if not the last character
                if (counter < searchTerm.Length - 1)
                {
                    path += ",";
                    counter++;
                }

                // Set new current character
                if (c != ' ')
                    curr = c;
            }

            return path;
        }

        // Find the specified character on the keyboard
        public Coordinate FindCharacter(char key)
        {
            Coordinate ret = new Coordinate();

            // Get uppercase char for comparison
            char uKey = Char.ToUpper(key);

            // Loop through each row of the keyboard
            for (int x = 0; x < _keyboardLayout.Length; x++)
            {
                // Check for the specified character in the keyboard
                int pos = Array.IndexOf(_keyboardLayout[x], uKey);
                if (pos > -1)
                {
                    // Found the item, set the coordinate and stop looking
                    ret.X = x;
                    ret.Y = pos;
                }
            }

            return ret;
        }

        public string GetCharacterPath(char startChar, char endChar)
        {
            string ret = "";

            // Check for the special case of a space
            if (endChar == ' ')
            {
                ret = "S";
            }
            else
            {
                // Get the coordinate of the start character
                Coordinate start = FindCharacter(startChar);

                // Get the coordinate of the end character
                Coordinate end = FindCharacter(endChar);

                // Calculate the vertical movement
                int v = (int)start.X - (int)end.X;
                if (v > 0)
                {
                    // Positive vertical, move up
                    for (int i = 0; i < v; i++)
                        ret += "U,";
                }
                else
                {
                    // Negative vertical, move down
                    for (int i = v; i < 0; i++)
                        ret += "D,";
                }

                // Calculate the horizontal movement
                int h = (int)start.Y - (int)end.Y;
                if (h > 0)
                {
                    // Positive horizontal, move left
                    for (int i = 0; i < h; i++)
                        ret += "L,";
                }
                else
                {
                    // Negative horizontal, move right
                    for (int i = h; i < 0; i++)
                        ret += "R,";
                }

                // Append the select
                ret += "#";
            }

            return ret;
        }
        #endregion
    }
}
