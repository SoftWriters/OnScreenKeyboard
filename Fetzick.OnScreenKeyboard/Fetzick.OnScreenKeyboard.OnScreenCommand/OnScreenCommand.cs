using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fetzick.OnScreenKeyboard.OnScreenCommand
{
    public class OnScreenCommand
    {
        public static string GetCommand(string Command)
        {
            string value = string.Empty;
            
            Char[] letters = Command.ToCharArray();
            int[] letterPosition = new int[2];
            int[] oldLetterPosition = new int[2] { 1, 1 };


            foreach (Char letter in letters)
            {
                if (letter == ' ')
                {
                    value += "S,";
                }
                else
                {
                    letterPosition = GetPosition(letter);
                    value += GetNewPosition(oldLetterPosition[0], oldLetterPosition[1], letterPosition[0], letterPosition[1]);
                    oldLetterPosition = letterPosition;
                    value += "#,";
                }
            }

            // Get rid of last comma
            value = value.Remove(value.Length - 1);


            return value;
        }

        private static string GetNewPosition(int OldRow, int OldColumn, int NewRow, int NewColumn)
        {
            string value = string.Empty;
            int rowDiff = 0;
            int colDiff = 0;

            if (OldRow > NewRow)
            {
                rowDiff = OldRow - NewRow;
                for (int i = 0; i < rowDiff; i++)
                {
                    value += "U,";
                }
            }
            else
            {
                rowDiff = NewRow - OldRow;
                for (int i = 0; i < rowDiff; i++)
                {
                    value += "D,";
                }
            }

            if (OldColumn > NewColumn)
            {
                colDiff = OldColumn - NewColumn;
                for (int i = 0; i < colDiff; i++)
                {
                    value += "L,";
                }
            }
            else
            {
                colDiff = NewColumn - OldColumn;
                for (int i = 0; i < colDiff; i++)
                {
                    value += "R,";
                }
            }

            return value;
        }

        private static int[] GetPosition(Char letter)
        {
            int[] letterPosition = new int[2];

            switch (letter)
            {
                case 'A':
                    letterPosition = new int[] { 1, 1 };
                    break;
                case 'B':
                    letterPosition = new int[] { 1, 2 };
                    break;
                case 'C':
                    letterPosition = new int[] { 1, 3 };
                    break;
                case 'D':
                    letterPosition = new int[] { 1, 4 };
                    break;
                case 'E':
                    letterPosition = new int[] { 1, 5 };
                    break;
                case 'F':
                    letterPosition = new int[] { 1, 6 };
                    break;
                case 'G':
                    letterPosition = new int[] { 2, 1 };
                    break;
                case 'H':
                    letterPosition = new int[] { 2, 2 };
                    break;
                case 'I':
                    letterPosition = new int[] { 2, 3 };
                    break;
                case 'J':
                    letterPosition = new int[] { 2, 4 };
                    break;
                case 'K':
                    letterPosition = new int[] { 2, 5 };
                    break;
                case 'L':
                    letterPosition = new int[] { 2, 6 };
                    break;
                case 'M':
                    letterPosition = new int[] { 3, 1 };
                    break;
                case 'N':
                    letterPosition = new int[] { 3, 2 };
                    break;
                case 'O':
                    letterPosition = new int[] { 3, 3 };
                    break;
                case 'P':
                    letterPosition = new int[] { 3, 4 };
                    break;
                case 'Q':
                    letterPosition = new int[] { 3, 5 };
                    break;
                case 'R':
                    letterPosition = new int[] { 3, 6 };
                    break;
                case 'S':
                    letterPosition = new int[] { 4, 1 };
                    break;
                case 'T':
                    letterPosition = new int[] { 4, 2 };
                    break;
                case 'U':
                    letterPosition = new int[] { 4, 3 };
                    break;
                case 'V':
                    letterPosition = new int[] { 4, 4 };
                    break;
                case 'W':
                    letterPosition = new int[] { 4, 5 };
                    break;
                case 'X':
                    letterPosition = new int[] { 4, 6 };
                    break;
                case 'Y':
                    letterPosition = new int[] { 5, 1 };
                    break;
                case 'Z':
                    letterPosition = new int[] { 5, 2 };
                    break;
                case '1':
                    letterPosition = new int[] { 5, 3 };
                    break;
                case '2':
                    letterPosition = new int[] { 5, 4 };
                    break;
                case '3':
                    letterPosition = new int[] { 5, 5 };
                    break;
                case '4':
                    letterPosition = new int[] { 5, 6 };
                    break;
                case '5':
                    letterPosition = new int[] { 6, 1 };
                    break;
                case '6':
                    letterPosition = new int[] { 6, 2 };
                    break;
                case '7':
                    letterPosition = new int[] { 6, 3 };
                    break;
                case '8':
                    letterPosition = new int[] { 6, 4 };
                    break;
                case '9':
                    letterPosition = new int[] { 6, 5 };
                    break;
                case '0':
                    letterPosition = new int[] { 6, 6 };
                    break;
                case ' ':
                    letterPosition = new int[] { 0, 0 };
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
                //letterPosition = new int[] { 0, 0 };
                //break;
            }

            return letterPosition;
        }
    }
}
