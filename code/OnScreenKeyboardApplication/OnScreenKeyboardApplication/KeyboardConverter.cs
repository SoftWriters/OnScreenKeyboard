using System;

namespace OnScreenKeyboardApplication
{
    class KeyboardConverter
    {
        private string keyboardMovementsLine;
        private KeyboardMapping currentMapping;

        public string ConvertLines(string inputLines)
        {
            string[] splitInputLines = inputLines.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            string convertedLines = "";

            foreach (string inputLine in splitInputLines)
            {
                convertedLines += ChangeToKeyboardMovements(inputLine) + "\n";
            }
            return convertedLines;
        }

        private string ChangeToKeyboardMovements(string inputLine)
        {
            keyboardMovementsLine = "";

            currentMapping = new KeyboardMapping();

            foreach (char inputCharacter in inputLine)
            {
                if (currentMapping.SpaceCharacter(inputCharacter))
                {
                    keyboardMovementsLine += "S" + ",";
                }
                else
                {
                    AddKeyboardPositionMovements(inputCharacter);
                }

                AddSelectCharacter();
            }

            RemoveFinalComma();

            return keyboardMovementsLine;
        }

        private void RemoveFinalComma()
        {
            keyboardMovementsLine.Remove(keyboardMovementsLine.Length - 1);
        }

        private void AddKeyboardPositionMovements(char inputCharacter)
        {
            int verticalMoves = currentMapping.FindVerticalMovement(inputCharacter);
            int horizontalMoves = currentMapping.FindHorizontalMovement(inputCharacter);

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
