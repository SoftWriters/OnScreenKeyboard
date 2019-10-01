using System;

namespace OnScreenKeyboardApplication
{
    class KeyboardConverter
    {
        public string ConvertLines(string inputLines)
        {
            string[] splitInputLines = inputLines.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            foreach (string inputLine in splitInputLines)
            {

            }
            return splitInputLines[0];
        }
    }
}
