using System;

namespace OnScreenKeyboardApplication
{
    class KeyboardConverter
    {
        private string keyboardMovementsLine;
        private KeyboardMapping keyboardMap;

        public string ConvertLines(string inputLines)
        {
            string[] splitInputLines = inputLines.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            string convertedLines = "";

            // Convert each separate line of the text file into keyboard movements
            foreach (string inputLine in splitInputLines)
            {
                convertedLines += ConvertToKeyboardMovements(inputLine) + "\n";
            }

            return convertedLines;
        }

        private string ConvertToKeyboardMovements(string inputLine)
        {
            keyboardMovementsLine = "";

            // Our keyboard mapping can convert characters into keyboard movements
            keyboardMap = new KeyboardMapping();

            foreach (char inputCharacter in inputLine)
            {
                if (keyboardMap.IsSpaceCharacter(inputCharacter))
                {
                    keyboardMovementsLine += "S" + ",";
                }
                else
                {
                    // Ensure all characters are uppercase to avoid confusion in handling them
                    AddKeyboardPositionMovements(char.ToUpper(inputCharacter));
                    AddSelectCharacter();
                }
            }

            keyboardMovementsLine = RemoveFinalCommaFromMovements();

            return keyboardMovementsLine;
        }

        private string RemoveFinalCommaFromMovements()
        {
            return keyboardMovementsLine.Remove(keyboardMovementsLine.Length - 1);
        }

        private void AddKeyboardPositionMovements(char inputCharacter)
        {
            int verticalMoves = keyboardMap.FindVerticalMovement(inputCharacter);
            int horizontalMoves = keyboardMap.FindHorizontalMovement(inputCharacter);

            AddVerticalMovement(verticalMoves);
            AddHorizontalMovement(horizontalMoves);
        }

        private void AddVerticalMovement(int verticalMoves)
        {
            for (int i = 0; i < Math.Abs(verticalMoves); i++)
            {
                if (verticalMoves < 0)
                {
                    keyboardMovementsLine += "U" + ",";
                }
                else
                {
                    keyboardMovementsLine += "D" + ",";
                }
            }
        }

        private void AddHorizontalMovement(int horizontalMoves)
        {
            for (int i = 0; i < Math.Abs(horizontalMoves); i++)
            {
                if (horizontalMoves < 0)
                {
                    keyboardMovementsLine += "L" + ",";
                }
                else
                {
                    keyboardMovementsLine += "R" + ",";
                }
            }
        }

        private void AddSelectCharacter()
        {
            keyboardMovementsLine += "#" + ",";
        }
    }
}
