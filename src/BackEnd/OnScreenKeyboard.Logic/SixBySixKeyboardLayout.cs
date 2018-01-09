using System;
using System.Collections.Generic;
using System.Text;

namespace OnScreenKeyboard.Logic
{
    public class SixBySixKeyboardLayout : IKeyboardLayout
    {
        private static char[] _keys =
        {
            'A', 'B', 'C', 'D', 'E', 'F',
            'G', 'H', 'I', 'J', 'K', 'L',
            'M', 'N', 'O', 'P', 'Q', 'R',
            'S', 'T', 'U', 'V', 'W', 'X',
            'Y', 'Z', '1', '2', '3', '4',
            '5', '6', '7', '8', '9', '0',
        };

        public KeyLocation? GetKeyLocation(char key)
        {
            int keyIndex = Array.IndexOf(_keys, char.ToUpper(key));
            return keyIndex < 0 ? (KeyLocation?)null
                : new KeyLocation { Row = keyIndex / 6, Column = keyIndex % 6 };
        }
    }
}
