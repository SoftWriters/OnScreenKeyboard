using KeyboardInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScreenKeyboard
{
    /// <summary>
    /// This ScreenKeyboard implementation based on Ascii code of letters 'A'-'Z' and digits '0'-'9'
    /// This ScreenKeyboard implementation based on ketboard size equals to 6 ! only
    /// </summary>
    public class ScreenKeyboardInst : IScreenKeyboard
    {
        private const int KeyboardRowSize = 6;

        public string StringToKeyboard(string inputString)
        {
            StringBuilder sb = new StringBuilder();

            char[] inputChars = inputString.ToUpper().ToCharArray();

            //the cursor will always start on the A
            int prevPosition = GetKeyCode('A');

            sb.Append(GetKeyboardCode(ref prevPosition, inputChars[0]));
            sb.Append(",");

            for (int i = 1; i < inputChars.Length; i++)
            {
                sb.Append(GetKeyboardCode(ref prevPosition, inputChars[i]));
                if (i != (inputChars.Length - 1))
                    sb.Append(",");
            }

            return sb.ToString();
        }

        public string KeyboardToString(string inputKeyboardCode)
        {
            StringBuilder sb = new StringBuilder();
            string[] strCodes = inputKeyboardCode.Split(',');
            for (int i = 0; i < strCodes.Length; i++)
            {
                string strCode = strCodes[i];

                if (strCode.Equals("S"))
                {
                    sb.Append(" ");
                }
            }
            return sb.ToString();
        }

        private int GetKeyCode(char inputChar)
        {
            if (inputChar >= 'A' && inputChar <= 'Z')
            {
                return (int)(inputChar - 'A');
            }
            else if (inputChar >= '0' && inputChar <= '9')
            {
                return (int)(inputChar - '0') + 'Z' + 1;
            }

            throw new Exception("Incorrect character");
        }

        private string GetKeyboardCode(ref int prevPosition, char nextChar)
        {
            StringBuilder sb = new StringBuilder();

            if (nextChar == ' ')
            {
                sb.Append("S");
            }
            else
            {
                int nextPosition = GetKeyCode(nextChar);

                int nVerticalMove = GetVerticalMove(prevPosition, nextPosition);
                int nHorizontalMove = GetHorizontalMove(prevPosition, nextPosition);

                sb.Append(GetVerticalKeySequence(nVerticalMove));
                sb.Append(GetHorizontalKeySequence(nHorizontalMove));

                sb.Append("#");

                prevPosition = nextPosition;
            }
            return sb.ToString();
        }

        private int GetVerticalMove(int prevSymbol, int nextSymbol)
        {
            return nextSymbol / KeyboardRowSize - prevSymbol / KeyboardRowSize;
        }

        private int GetHorizontalMove(int prevSymbol, int nextSymbol)
        {
            return nextSymbol % KeyboardRowSize - prevSymbol % KeyboardRowSize;
        }

        private string GetVerticalKeySequence(int nVerticalMove)
        {
            StringBuilder sb = new StringBuilder();
            if (IsDown(nVerticalMove))
                sb.Append(GetKeySequance(nVerticalMove, 'D'));
            else if (IsUp(nVerticalMove))
                sb.Append(GetKeySequance(nVerticalMove * -1, 'U'));

            return sb.ToString();
        }

        private string GetHorizontalKeySequence(int nHorizontalMove)
        {
            StringBuilder sb = new StringBuilder();

            if (IsRigth(nHorizontalMove))
                sb.Append(GetKeySequance(nHorizontalMove, 'R'));
            else if (IsLeft(nHorizontalMove))
                sb.Append(GetKeySequance(nHorizontalMove * -1, 'L'));

            return sb.ToString();
        }

        private bool IsLeft(int nHorizontalMove)
        {
            return nHorizontalMove < 0;
        }

        private bool IsRigth(int nHorizontalMove)
        {
            return nHorizontalMove > 0;
        }

        private bool IsUp(int nVerticalMove)
        {
            return nVerticalMove < 0;
        }

        private bool IsDown(int nVerticalMove)
        {
            return nVerticalMove > 0;
        }

        private string GetKeySequance(int nSteps, char key)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < nSteps; i++)
            {
                sb.Append(key);
                sb.Append(",");
            }
            return sb.ToString();
        }
    }
}
