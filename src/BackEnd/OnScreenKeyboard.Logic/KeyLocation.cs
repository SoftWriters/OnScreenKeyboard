using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace OnScreenKeyboard.Logic
{
    public struct KeyLocation
    {
        public int Row;
        public int Column;

        public static KeyLocation operator +(KeyLocation a, KeyLocation b)
            => new KeyLocation { Row = a.Row + b.Row, Column = a.Column + b.Column };
        public static KeyLocation operator -(KeyLocation a, KeyLocation b)
            => new KeyLocation { Row = a.Row - b.Row, Column = a.Column - b.Column };
    }
}
