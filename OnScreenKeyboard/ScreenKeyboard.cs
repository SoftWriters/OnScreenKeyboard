using System;
using System.Text;

namespace OnScreenKeyboard
{
    /// <summary>
    /// This ScreenKeyboard implementation based on index of charachter in constant charachters array defined as string for simple implementation
    /// This ScreenKeyboard implementation based on keyboard 6X6
    /// </summary>
    public class ScreenKeyboard : IScreenKeyboard
    {
        private const int KeyboardRowSize = 6;

        private const char LeftCode = 'L';
        private const char RightCode = 'R';
        private const char UpCode = 'U';
        private const char DownCode = 'D';
        private const char SelectCode = '#';
        private const char SpaceCode = 'S';
        private const char SeparatorCode = ',';

        private const string KeyboardCodes = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

        // Implement main action of this task
        public string StringToKeyboard(string inputString)
        {
            StringBuilder sb = new StringBuilder();

            char[] inputChars = inputString.ToUpper().ToCharArray();

            //the cursor will always start on the A
            char prevChar = KeyboardCodes[0];

            foreach (char nextChar in inputChars)
            {
                /// append sequence codes and separator
                sb.Append(GetKeyboardSequenceCodes(prevChar, nextChar));
                sb.Append(SeparatorCode);

                if (nextChar != ' ')
                {
                    // Space is specific characher is not perticipate in key sequence codes creation
                    // In case of current charachter is space the previuse charachter should be skip the same
                    prevChar = nextChar;
                }
            }



            // remove last separator (by the task definition output string should not be ended with ',')
            sb.Remove(sb.Length - 1, 1);

            return sb.ToString();
        }

        // Convertation one charachter to psedo "ascii" code. 
        // Base on ASCII code with correction for digits
        private int GetKeyCode(char inputChar)
        {
            int iIndex = KeyboardCodes.IndexOf(inputChar);
            if(iIndex < 0)
            {
                throw new ArgumentException($"Incorrect charachter {inputChar}" );
            }

            return iIndex;
        }

        // To get DVR keyboard code from previuse position to next charachter
        private string GetKeyboardSequenceCodes(char prevChar, char nextChar)
        {
            if (nextChar == ' ')
            {
                // return space code
                return SpaceCode.ToString();
            }
            if (prevChar == nextChar)
            {
                // return select code
                return SelectCode.ToString();
            }

            // get position of next symbol
            int prevPosition = GetKeyCode(prevChar);
            // get position of next symbol
            int nextPosition = GetKeyCode(nextChar);

            StringBuilder sb = new StringBuilder();

            // get vertical and horizontal number of steps to move a cursor
            int nVerticalMove = GetVerticalMove(prevPosition, nextPosition);
            int nHorizontalMove = GetHorizontalMove(prevPosition, nextPosition);

            // add vertical and horizontal codes of the cursor
            sb.Append(GetVerticalKeySequence(nVerticalMove));
            sb.Append(GetHorizontalKeySequence(nHorizontalMove));

            // add "select" code
            sb.Append(SelectCode);

            return sb.ToString();
        }

        // Get how vertical steps to move a cursor
        private int GetVerticalMove(int prevSymbol, int nextSymbol)
        {
            return nextSymbol / KeyboardRowSize - prevSymbol / KeyboardRowSize;
        }

        // Get how horizontal steps to move a cursor
        private int GetHorizontalMove(int prevSymbol, int nextSymbol)
        {
            return nextSymbol % KeyboardRowSize - prevSymbol % KeyboardRowSize;
        }

        // Get sequence codes string for vertical moving
        private string GetVerticalKeySequence(int nVerticalMove)
        {
            StringBuilder sb = new StringBuilder();

            if (IsDown(nVerticalMove))
                sb.Append(GetKeySequance(nVerticalMove, DownCode));
            else if (IsUp(nVerticalMove))
                sb.Append(GetKeySequance(nVerticalMove * -1, UpCode));

            return sb.ToString();
        }

        // Get sequence codes string for horizontal moving
        private string GetHorizontalKeySequence(int nHorizontalMove)
        {
            StringBuilder sb = new StringBuilder();

            if (IsRigth(nHorizontalMove))
                sb.Append(GetKeySequance(nHorizontalMove, RightCode));
            else if (IsLeft(nHorizontalMove))
                sb.Append(GetKeySequance(nHorizontalMove * -1, LeftCode));

            return sb.ToString();
        }

        // Check is it move to left side
        private bool IsLeft(int nHorizontalMove)
        {
            return nHorizontalMove < 0;
        }

        // Check is it move to right side
        private bool IsRigth(int nHorizontalMove)
        {
            return nHorizontalMove > 0;
        }

        // Check is it move to up line
        private bool IsUp(int nVerticalMove)
        {
            return nVerticalMove < 0;
        }

        // Check is it move to down line
        private bool IsDown(int nVerticalMove)
        {
            return nVerticalMove > 0;
        }

        // Create sequence from key by step number 
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

        // Implementation for second (testing) funtion for validation that keyboard codes maybe returns to original string
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

        // Convert position to charachter. base on ascii code with correction for digits
        private char GetSymbolByPosition(int iPosition)
        {
            return KeyboardCodes[iPosition];
        }

        // Get next position of charachter by DVR code
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

            throw new ArgumentException("Incorrect key");
        }

        // Is Left DVR code
        private bool IsLeft(string nHorizontalMove)
        {
            return nHorizontalMove.Equals(LeftCode.ToString());
        }

        // Is Right DVR code
        private bool IsRigth(string nHorizontalMove)
        {
            return nHorizontalMove.Equals(RightCode.ToString());
        }

        // Is Up DVR code
        private bool IsUp(string nVerticalMove)
        {
            return nVerticalMove.Equals(UpCode.ToString());
        }

        // Is Down DVR code
        private bool IsDown(string nVerticalMove)
        {
            return nVerticalMove.Equals(DownCode.ToString());
        }
    }
}
