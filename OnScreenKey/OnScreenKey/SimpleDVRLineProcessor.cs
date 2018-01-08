using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnScreenKey
{
    /// <summary>
    /// The reference implementation of the DVR Line Processor Interface. Uses the DVR Constants interface.
    /// </summary>
    class SimpleDVRLineProcessor : AbstractDVRLineProcessor
    {
        private static AbstractDVRConstants dvrConstants;
        private static String DVRCharactersString = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        private static int DVRCharsPerRow = 6;

        /// <summary>
        /// The reference implementation of the processLine method.
        /// </summary>
        /// <param name="inLine">The plaintext string to process into a series of DVR commands.</param>
        /// <returns>Returns an output string, delimited by AbstractDVRConstants.Separator().</returns>
        /// <remarks>Current handling assumptions:
        /// Any string consisting only of whitespace is not a valid command and will return blanks.
        /// Any character not in the reference map is ignored.</remarks>
        public override String processLine(String inLine)
        {
            String outLine = "";

            if (!(String.IsNullOrWhiteSpace(inLine)))
            {

                StringBuilder outLineBuilder = new StringBuilder();

                // cast inLine to uppercase to match the standard character string
                // break the string into a character array
                List<Char> characterList = new List<Char>(inLine.ToUpper().ToCharArray());

                // establish initial loop conditions
                Char prevChar = 'A';
                int oldPos, oldX, oldY, newPos, newX, newY, xdist, ydist;
                String XChar, YChar;

                foreach (Char nextChar in characterList) {

                    // if a character is a space, output the space character and a separator
                    // do not change previous character position.
                    if (Char.IsWhiteSpace(nextChar))
                    {
                        outLineBuilder.Append(dvrConstants.Space).Append(dvrConstants.Separator);
                    }
                    else
                    {

                        newPos = DVRCharactersString.IndexOf(nextChar);

                        // if a character isn't found in the reference string, skip it
                        if (newPos > -1)
                        {

                            // x and y coordinates in the rectangular array are given by MOD and DIV the CharsPerRow value
                            oldPos = DVRCharactersString.IndexOf(prevChar);
                            oldX = oldPos % DVRCharsPerRow;
                            oldY = oldPos / DVRCharsPerRow;

                            newX = newPos % DVRCharsPerRow;
                            newY = newPos / DVRCharsPerRow;

                            xdist = newX - oldX;
                            ydist = newY - oldY;

                            // if there was a change in X coordinates
                            if (xdist != 0)
                            {
                                // work out whether we're moving left or right and assign character appropriately
                                XChar = (xdist < 0) ? dvrConstants.Left : dvrConstants.Right;

                                // append copies equal to the absolute distance
                                foreach (int i in Enumerable.Range(0, Math.Abs(xdist)))
                                {
                                    outLineBuilder.Append(XChar).Append(dvrConstants.Separator);
                                }

                            }

                            // if there was a change in Y coordinates
                            if (ydist != 0)
                            {
                                // work out whether we're moving left or right and assign character appropriately
                                YChar = (ydist < 0) ? dvrConstants.Up : dvrConstants.Down;

                                // append copies equal to the absolute distance
                                foreach (int i in Enumerable.Range(0, Math.Abs(ydist)))
                                {
                                    outLineBuilder.Append(YChar).Append(dvrConstants.Separator);
                                }

                            }

                            // lastly, append an enter character
                            outLineBuilder.Append(dvrConstants.Enter).Append(dvrConstants.Separator);

                            // and set up previous character for the next loop
                            prevChar = nextChar;

                        }

                    }

                }

                // if there is a string in the builder it now has a superfluous final comma. Trim that.
                int outLineLength = outLineBuilder.Length;
                if (outLineLength > 0)
                {
                    outLineBuilder.Remove(outLineLength - 1, 1);
                }
                outLine = outLineBuilder.ToString();

            }

            return outLine;
        }

        /// <summary>
        /// The only currently supported constructor.
        /// </summary>
        /// <param name="inConstants">Requires an implementation of the DVR Constants interface, set at initialization.</param>
        public SimpleDVRLineProcessor(AbstractDVRConstants inConstants)
        {
            dvrConstants = inConstants;
        }
    }
}
