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
            return Convert.ToInt32(inputCharacter);
        }

        public int FindNewYPosition(int characterValue)
        {
            int convertedYPosition = 0;

            if (IsLetter(characterValue))
            {
                convertedYPosition = (characterValue - 65) / 6;
            }
            else if(IsNumber(characterValue))
            {
                convertedYPosition = (characterValue - 23) / 6;
            }
            else if (IsZero(characterValue))
            {
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
            return characterValue > 64 && characterValue < 91;
        }

        public bool IsNumber(int characterValue)
        {
            return characterValue > 48 && characterValue < 58;
        }

        public bool IsZero(int characterValue)
        {
            return characterValue == 48;
        }
    }
}
