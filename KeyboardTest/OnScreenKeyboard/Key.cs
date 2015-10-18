using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnScreenKeyboard
{
    class Key
    {
        private string value;
        private Position keyPosition;

        public string Value { get { return value; } }
        public Position KeyPosition { get { return keyPosition; } }

        public Key(string letter, Position position)
        {
            this.value = letter;
            this.keyPosition = position;
        }
    }
}
