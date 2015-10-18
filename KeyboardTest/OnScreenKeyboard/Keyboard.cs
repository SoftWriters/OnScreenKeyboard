using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnScreenKeyboard
{
    class Keyboard
    {
        private Key[] keyBoard = { new Key("A", new Position(0, 0)),
                                   new Key("B", new Position(0, 1)),
                                   new Key("C", new Position(0, 2)),
                                   new Key("D", new Position(0, 3)),
                                   new Key("E", new Position(0, 4)),
                                   new Key("F", new Position(0, 5)),
                                   new Key("G", new Position(1, 0)),
                                   new Key("H", new Position(1, 1)),
                                   new Key("I", new Position(1, 2)),
                                   new Key("J", new Position(1, 3)),
                                   new Key("K", new Position(1, 4)),
                                   new Key("L", new Position(1, 5)),
                                   new Key("M", new Position(2, 0)),
                                   new Key("N", new Position(2, 1)),
                                   new Key("O", new Position(2, 2)),
                                   new Key("P", new Position(2, 3)),
                                   new Key("Q", new Position(2, 4)),
                                   new Key("R", new Position(2, 5)),
                                   new Key("S", new Position(3, 0)),
                                   new Key("T", new Position(3, 1)),
                                   new Key("U", new Position(3, 2)),
                                   new Key("V", new Position(3, 3)),
                                   new Key("W", new Position(3, 4)),
                                   new Key("X", new Position(3, 5)),
                                   new Key("Y", new Position(4, 0)),
                                   new Key("Z", new Position(4, 1)),
                                   new Key("1", new Position(4, 2)),
                                   new Key("2", new Position(4, 3)),
                                   new Key("3", new Position(4, 4)),
                                   new Key("4", new Position(4, 5)),
                                   new Key("5", new Position(5, 0)),
                                   new Key("6", new Position(5, 1)),
                                   new Key("7", new Position(5, 2)),
                                   new Key("8", new Position(5, 3)),
                                   new Key("9", new Position(5, 4)),
                                   new Key("0", new Position(5, 5)),};
        private int numKeys;

        public Keyboard()
        {
            this.numKeys = keyBoard.Length;
        }

        /// <summary>
        /// Method to search the keyboard by key value to find a key
        /// null return signifies value not found, Not case sensitive
        /// </summary>
        /// <param name="letter"></param>
        /// <returns></returns>
        public Key GetSelectedKey(string letter)
        {
            Boolean keyFound = false;
            int counter = 0;
            Key invalidKey = null;

            //Check for Space key
            if (letter == " ")
            {
                return new Key(" ", new Position(-1, -1));
            }

            while (!keyFound && counter < numKeys)
            {
                Key compareKey = keyBoard[counter];
                if (letter.ToUpper() == compareKey.Value)
                {
                    return compareKey;
                }
                counter++;
            }

            return invalidKey;
        }
    }
}
