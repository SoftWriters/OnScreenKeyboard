using System;

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
            int characterValue = ConvertCharacterToInt(inputCharacter);

            int newYPosition = FindNewYPosition(characterValue);

            // Change in position of characters across keyboard
            int verticalMovement = newYPosition - currentYPosition;

            currentYPosition = newYPosition;

            return verticalMovement;
        }

        public int FindHorizontalMovement(char inputCharacter)
        {
            int characterValue = ConvertCharacterToInt(inputCharacter);

            int newXPosition = FindNewXPosition(characterValue);

            int horizontalMovement = newXPosition - currentXPosition;

            currentXPosition = newXPosition;

            return horizontalMovement;
        }

        public int ConvertCharacterToInt(char inputCharacter)
        {
            // Standard system of converting characters to integer values
            return Convert.ToInt32(inputCharacter);
        }

        public int FindNewYPosition(int characterValue)
        {
            int convertedYPosition = 0;

            if (IsLetter(characterValue))
            {
                // Letters begin at a value of 65 with 'A', so now we start them at index 0 of essentially a keyboard array
                convertedYPosition = (characterValue - 65) / 6;
            }
            else if(IsNumber(characterValue))
            {
                // Numbers begin at a value of 49 with '1', so we now start them at 26, right after our letters in the keyboard
                convertedYPosition = (characterValue - 23) / 6;
            }
            else if (IsZero(characterValue))
            {
                // 0 is at the fifth position of our keyboard array
                convertedYPosition = 5;
            }

            return convertedYPosition;
        }

        public int FindNewXPosition(int characterValue)
        {
            int convertedXPosition = 0;

            if (IsLetter(characterValue))
            {
                convertedXPosition = (characterValue - 65) % 6;
            }
            else if (IsNumber(characterValue))
            {
                convertedXPosition = (characterValue - 23) % 6;
            }
            else if (IsZero(characterValue))
            {
                convertedXPosition = 5;
            }

            return convertedXPosition;
        }

        public bool IsLetter(int characterValue)
        {
            // Converted values for uppercase letters from characters
            return characterValue > 64 && characterValue < 91;
        }

        public bool IsNumber(int characterValue)
        {
            // Converted values for numbers from characters
            return characterValue > 48 && characterValue < 58;
        }

        public bool IsZero(int characterValue)
        {
            // Character converted value of 0
            return characterValue == 48;
        }
    }
}
