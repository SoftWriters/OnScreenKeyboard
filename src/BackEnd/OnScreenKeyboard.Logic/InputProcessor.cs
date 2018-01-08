using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace OnScreenKeyboard.Logic
{
    public class InputProcessor
    {
        public InputProcessor(IKeyboardLayout keyboardLayout)
        {
            _keyboardLayout = keyboardLayout ?? throw new ArgumentNullException(nameof(keyboardLayout));
        }

        private IKeyboardLayout _keyboardLayout;

        /// <summary>
        /// Convert all characters to upper case, all punctuation to spaces and remove any repeated
        /// spaces.
        /// </summary>
        public string ScrubInput(string input)
        {
            if (input == null)
                return null;

            bool lastCharWasSpace = false;
            var sb = new StringBuilder();

            foreach(char c in input.Trim().ToUpper())
            {
                char cc = (char.IsPunctuation(c) || char.IsSymbol(c)) ? ' ' : c;
                if (cc == ' ')
                {
                    if (lastCharWasSpace) continue;
                    else lastCharWasSpace = true;
                }
                else
                    lastCharWasSpace = false;
                sb.Append(cc);
            }

            return sb.ToString().Trim();
        }

        /// <summary>
        /// Convert an input string into instructions to move the cursor around the on screen keyboard.
        /// </summary>
        public string ToCursorInstructions(string input)
        {
            var keySequences = ToKeyLocationSequences(input);
            if (keySequences == null)
                return null;

            var currentLocation = new KeyLocation { Row = 0, Column = 0 };
            return 
                string.Join(",S,",
                    keySequences.Select(seq => string.Join(",",
                        seq.Select(
                            keyLoc =>
                            {
                                var result = ToRelativeCursorInstructions(currentLocation, keyLoc);
                                currentLocation = keyLoc;
                                return result;
                            }))));

        }

        /// <summary>
        /// Convert an input string into a sequence of key locations seperated by spaces.
        /// </summary>
        private List<List<KeyLocation>> ToKeyLocationSequences(string input)
            => ScrubInput(input)?.Split(' ')
                ?.Select(word =>
                    word.Select(c => _keyboardLayout.GetKeyLocation(c))
                        .Where(kl => kl != null)
                        .Cast<KeyLocation>()
                        .ToList())
                ?.ToList();

        /// <summary>
        /// Generate the instructions to move from one key to another.
        /// </summary>
        private string ToRelativeCursorInstructions(KeyLocation currentLocation, KeyLocation targetLocation)
        {
            var diff = targetLocation - currentLocation;
            var sb = new StringBuilder();

            for (int i = 0; i < diff.Column; i++)
                sb.Append("R,");
            for (int i = 0; i > diff.Column; i--)
                sb.Append("L,");
            for (int i = 0; i < diff.Row; i++)
                sb.Append("D,");
            for (int i = 0; i > diff.Row; i--)
                sb.Append("U,");

            sb.Append("#");


            return sb.ToString();
        }

    }
}
