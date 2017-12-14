using KeyboardInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScreenKeyboard
{
    /// <summary>
    /// This ScreenKeyboard implementation based on Ascii code of letters 'A'-'Z' and digits '0'-'9'
    /// This ScreenKeyboard implementation based on ketboard size equals to 6 
    /// </summary>
    public class ScreenKeyboardInst : IScreenKeyboard
    {
        private const int KeyboardRowSize = 6;

        private const char LeftCode = 'L';
        private const char RightCode = 'R';
        private const char UpCode = 'U';
        private const char DownCode = 'D';
        private const char SelectCode = '#';
        private const char SpaceCode = 'S';
        private const char SeparatorCode = ',';

        private const char FirstLetterSymbol = 'A';
        private const char LastLetterSymbol = 'Z';
        private const char FirstDigitSymbol = '0';
        private const char LastDigitSymbol = '9';

        /// <summary>
        /// Main public entry. Function allows to convert input string to DVR ketboard codes.
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns>The string of DVR ketboard codes</returns>
        public string StringToKeyboard(string inputString)
        {
            StringBuilder sb = new StringBuilder();

            char[] inputChars = inputString.ToUpper().ToCharArray();

            //the cursor will always start on the A
            int prevPosition = GetKeyCode(FirstLetterSymbol);

            sb.Append(GetKeyboardCode(ref prevPosition, inputChars[0]));
            sb.Append(SeparatorCode);

            for (int i = 1; i < inputChars.Length; i++)
            {
                sb.Append(GetKeyboardCode(ref prevPosition, inputChars[i]));
                if (i != (inputChars.Length - 1))
                    sb.Append(SeparatorCode);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Convertation one charachter to psedo "ascii" code. 
        /// Base on ASCII code with correction for digits
        /// </summary>
        /// <param name="inputChar"></param>
        /// <returns>Integer code</returns>
        private int GetKeyCode(char inputChar)
        {
            if (inputChar >= FirstLetterSymbol && inputChar <= LastLetterSymbol)
            {
                return (int)(inputChar - FirstLetterSymbol);
            }
            else if (inputChar >= FirstDigitSymbol && inputChar <= LastDigitSymbol)
            {
                return (int)(inputChar - FirstDigitSymbol) + LastLetterSymbol + 1;
            }

            throw new Exception(string.Format("Incorrect character '{0}'", inputChar));
        }

        /// <summary>
        /// To get DVR keyboard code from previuse position to next charachter
        /// </summary>
        /// <param name="prevPosition">intput & output parameter</param>
        /// <param name="nextChar"></param>
        /// <returns>string of sequence codes</returns>
        private string GetKeyboardCode(ref int prevPosition, char nextChar)
        {
            StringBuilder sb = new StringBuilder();

            if (nextChar == ' ')
            {
                // just add space
                sb.Append(SpaceCode);
            }
            else
            {
                // get position of next symbol
                int nextPosition = GetKeyCode(nextChar);

                // get vertical and horizontal number of steps to move a cursor
                int nVerticalMove = GetVerticalMove(prevPosition, nextPosition);
                int nHorizontalMove = GetHorizontalMove(prevPosition, nextPosition);

                // add vertical and horizontal codes of the cursor
                sb.Append(GetVerticalKeySequence(nVerticalMove));
                sb.Append(GetHorizontalKeySequence(nHorizontalMove));

                // add "select" code
                sb.Append(SelectCode);

                prevPosition = nextPosition;
            }
            return sb.ToString();
        }

        /// <summary>
        /// Get how vertical steps to move a cursor
        /// </summary>
        /// <param name="prevSymbol"></param>
        /// <param name="nextSymbol"></param>
        /// <returns></returns>
        private int GetVerticalMove(int prevSymbol, int nextSymbol)
        {
            return nextSymbol / KeyboardRowSize - prevSymbol / KeyboardRowSize;
        }

        /// <summary>
        /// Get how horizontal steps to move a cursor
        /// </summary>
        /// <param name="prevSymbol"></param>
        /// <param name="nextSymbol"></param>
        /// <returns></returns>
        private int GetHorizontalMove(int prevSymbol, int nextSymbol)
        {
            return nextSymbol % KeyboardRowSize - prevSymbol % KeyboardRowSize;
        }

        /// <summary>
        /// Get sequence codes string for vertical moving
        /// </summary>
        /// <param name="nVerticalMove"></param>
        /// <returns>string of codes</returns>
        private string GetVerticalKeySequence(int nVerticalMove)
        {
            StringBuilder sb = new StringBuilder();
            if (IsDown(nVerticalMove))
                sb.Append(GetKeySequance(nVerticalMove, DownCode));
            else if (IsUp(nVerticalMove))
                sb.Append(GetKeySequance(nVerticalMove * -1, UpCode));

            return sb.ToString();
        }

        /// <summary>
        /// Get sequence codes string for horizontal moving
        /// </summary>
        /// <param name="nHorizontalMove"></param>
        /// <returns>string of codes</returns>
        private string GetHorizontalKeySequence(int nHorizontalMove)
        {
            StringBuilder sb = new StringBuilder();

            if (IsRigth(nHorizontalMove))
                sb.Append(GetKeySequance(nHorizontalMove, RightCode));
            else if (IsLeft(nHorizontalMove))
                sb.Append(GetKeySequance(nHorizontalMove * -1, LeftCode));

            return sb.ToString();
        }

        /// <summary>
        /// Check is it move to left side
        /// </summary>
        /// <param name="nHorizontalMove"></param>
        /// <returns></returns>
        private bool IsLeft(int nHorizontalMove)
        {
            return nHorizontalMove < 0;
        }

        /// <summary>
        /// Check is it move to right side
        /// </summary>
        /// <param name="nHorizontalMove"></param>
        /// <returns></returns>
        private bool IsRigth(int nHorizontalMove)
        {
            return nHorizontalMove > 0;
        }

        /// <summary>
        /// Check is it move to up line
        /// </summary>
        /// <param name="nVerticalMove"></param>
        /// <returns></returns>
        private bool IsUp(int nVerticalMove)
        {
            return nVerticalMove < 0;
        }

        /// <summary>
        /// Check is it move to down line
        /// </summary>
        /// <param name="nVerticalMove"></param>
        /// <returns></returns>
        private bool IsDown(int nVerticalMove)
        {
            return nVerticalMove > 0;
        }

        /// <summary>
        /// create sequence from key by step number 
        /// </summary>
        /// <param name="nSteps"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private string GetKeySequance(int nSteps, char key)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < nSteps; i++)
            {
                sb.Append(key);
                sb.Append(SeparatorCode);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Test public entry for validation that keyboard codes maybe returns to original string
        /// </summary>
        /// <param name="inputKeyboardCode"></param>
        /// <returns>The original string</returns>
        public string KeyboardToString(string inputKeyboardCode)
        {
            StringBuilder sb = new StringBuilder();
            string[] strCodes = inputKeyboardCode.Split(SeparatorCode);

            //the cursor will always start on the A
            int iPosition = 0;

            for (int i = 0; i < strCodes.Length; i++)
            {
                string strCode = strCodes[i];

                if (strCode.Equals(SpaceCode.ToString()))
                {
                    sb.Append(" ");
                }
                else if (!strCode.Equals(SelectCode.ToString()))
                {
                    iPosition = GetNextPositionByCode(iPosition, strCode);
                }
                else
                {
                    sb.Append(GetSymbolByPosition(iPosition));
                }
                
            }
            return sb.ToString();
        }

        /// <summary>
        /// Convert position to charachter. base on ascii code with correction for digits
        /// </summary>
        /// <param name="iPosition"></param>
        /// <returns></returns>
        private char GetSymbolByPosition(int iPosition)
        {
            char c = (char)(iPosition + FirstLetterSymbol);

            if(c > LastLetterSymbol)
            {
                c = (char)(iPosition - LastLetterSymbol + FirstDigitSymbol - 1);
            }

            return c;
        }

        /// <summary>
        /// Get next position of charachter by DVR code
        /// </summary>
        /// <param name="prevPosition"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        private int GetNextPositionByCode(int prevPosition, string key)
        {
            if (IsDown(key))
                return prevPosition + KeyboardRowSize;

            if (IsUp(key))
                return prevPosition - KeyboardRowSize;

            if (IsRigth(key))
                return prevPosition + 1;

            if (IsLeft(key))
                return prevPosition - 1;

            throw new Exception("Incorrect key");
        }

        /// <summary>
        /// is Left DVR code
        /// </summary>
        /// <param name="nHorizontalMove"></param>
        /// <returns></returns>
        private bool IsLeft(string nHorizontalMove)
        {
            return nHorizontalMove.Equals(LeftCode.ToString());
        }

        /// <summary>
        /// is Right DVR code
        /// </summary>
        /// <param name="nHorizontalMove"></param>
        /// <returns></returns>
        private bool IsRigth(string nHorizontalMove)
        {
            return nHorizontalMove.Equals(RightCode.ToString());
        }

        /// <summary>
        /// is Up DVR code
        /// </summary>
        /// <param name="nVerticalMove"></param>
        /// <returns></returns>
        private bool IsUp(string nVerticalMove)
        {
            return nVerticalMove.Equals(UpCode.ToString());
        }

        /// <summary>
        /// is Down DVR code
        /// </summary>
        /// <param name="nVerticalMove"></param>
        /// <returns></returns>
        private bool IsDown(string nVerticalMove)
        {
            return nVerticalMove.Equals(DownCode.ToString());
        }
    }
}
