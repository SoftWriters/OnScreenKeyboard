using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnScreenKeyboardApplication
{
    class KeyboardMapping
    {
        private int currentXPosition;
        private int currentYPosition;

        public KeyboardMapping()
        {
            currentXPosition = 0;
            currentYPosition = 0;
        }

        public bool IsSpaceCharacter(char inputCharacter)
        {
            return Char.IsWhiteSpace(inputCharacter);
        }

        public int FindVerticalMovement(char inputCharacter)
        {
            int newYPosition = 0;


            return newYPosition - currentYPosition;
        }

        public int FindHorizontalMovement(char inputCharacter)
        {
            int newXPosition = 0;


            return newXPosition - currentXPosition;
        }
    }
}
