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

        public bool SpaceCharacter(char inputCharacter)
        {
            // Implement
            return false;
        }

        public int FindVerticalMovement(char inputCharacter)
        {
            return 0;
        }

        public int FindHorizontalMovement(char inputCharacter)
        {
            return 0;
        }
    }
}
