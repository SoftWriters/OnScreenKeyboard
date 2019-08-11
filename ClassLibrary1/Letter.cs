using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class Letter
    {
        public Letter(String character, int x, int y)
        {
            this.character = character;
            this.x = x;
            this.y = y;
        }
        public string character { get; set; }
        public int x { get; set; }
        public int y { get; set; }
    }
}
