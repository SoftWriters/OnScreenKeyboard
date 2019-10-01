using System;

namespace OnScreenKeyboardApplication
{
    class KeyboardConverter
    {
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
            return inputLine;
        }
    }
}
