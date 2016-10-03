using System;

namespace KeyboardWalker
{
    public class FindPattern
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
        public FindPattern(char[][] keyboardLayout = null)
        {
            // Check to see if a new keyboard layout was given
            if (keyboardLayout != null)
            {
                _keyboardLayout = keyboardLayout;
            }
        }
        #endregion

        #region Public Action Methods

        #endregion

        #region Public Helpers
        public Coordinate FindKey(char key)
        {
            Coordinate ret = new Coordinate();

            // Loop through each row of the keyboard
            for (int x = 0; x < _keyboardLayout.Length; x++)
            {
                // Check for the specified character in the keyboard
                int pos = Array.IndexOf(_keyboardLayout[x], key);
                if (pos > -1)
                {
                    // Found the item, set the coordinate and stop looking
                    ret.X = x;
                    ret.Y = pos;
                }
            }

            return ret;
        }
        #endregion
    }
}
