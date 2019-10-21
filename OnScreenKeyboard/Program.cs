using System;
using System.IO;

namespace OnScreenKeyboard
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFilePath = @"input.txt";
            var outputFilePath = @"output.txt";

            if (!File.Exists(inputFilePath))
            {
                string[] createText =
                {
                    "An Orange",
                    "<--Scube-->",
                    "Work Hard",
                    "app v.1.0.0",
                    "()()AA$$@@"
                };

                File.WriteAllLines(inputFilePath, createText);
            }

            var pathScript = "";

            string[] inputText = File.ReadAllLines(inputFilePath);

            foreach (var inputString in inputText)
            {
                pathScript = pathScript + (CursorTracker.GetCursorPathScript(inputString) + Environment.NewLine);
            }

            File.WriteAllText(outputFilePath, pathScript);
        }
    }
}
