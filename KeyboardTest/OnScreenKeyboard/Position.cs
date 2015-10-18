using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnScreenKeyboard
{
    class Position
    {
        private int x;
        private int y;

        public int X { get { return x; } }
        public int Y { get { return y; } }

        public Position(int xCoor, int yCoor)
        {
            this.x = xCoor;
            this.y = yCoor;
        }
    }
}
