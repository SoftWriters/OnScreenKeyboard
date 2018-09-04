using System;
using System.Collections.Generic;

namespace OnScreenKeyboard
{
    class Keyboard
    {
        private const int keyboardWidth = 6;
        private int homePosition = 0;

        public int getHomePosition()
        {
            return homePosition;
        }
        public int getKeyboardWidth()
        {
            return keyboardWidth;
        }

        private Dictionary<char, int> keyboardLayout = new Dictionary<char, int>()
        {
            { 'A', 0 },
            { 'B', 1 },
            { 'C', 2 },
            { 'D', 3 },
            { 'E', 4 },
            { 'F', 5 },
            { 'G', 6 },
            { 'H', 7 },
            { 'I', 8 },
            { 'J', 9 },
            { 'K', 10 },
            { 'L', 11 },
            { 'M', 12 },
            { 'N', 13 },
            { 'O', 14 },
            { 'P', 15 },
            { 'Q', 16 },
            { 'R', 17 },
            { 'S', 18 },
            { 'T', 19 },
            { 'U', 20 },
            { 'V', 21 },
            { 'W', 22 },
            { 'X', 23 },
            { 'Y', 24 },
            { 'Z', 25 },
            { '1', 26 },
            { '2', 27 },
            { '3', 28 },
            { '4', 29 },
            { '5', 30 },
            { '6', 31 },
            { '7', 32 },
            { '8', 33 },
            { '9', 34 },
            { '0', 35 }
        };

        public List<char> getKeyboardKeys()
        {
            List<char> returnArray = new List<char>();

            foreach (KeyValuePair<char, int> keyName in keyboardLayout)
            {
                returnArray.Add(keyName.Key);
            }

            return returnArray;
        }

        public char normalizeChar(char rawChar)
        {
            char returnValue = '\0';
            char inputChar = Char.ToUpper(rawChar);
            if (getKeyboardKeys().Contains(inputChar) || inputChar == ' ')
            {
                returnValue = inputChar;
            }
            return returnValue;
        }

        public string formatPathString(string unformattedPath)
        {
            string returnFormattedString = "";

            int idx = 0;
            while (idx < unformattedPath.Length - 1)
            {
                returnFormattedString += unformattedPath[idx++];
                returnFormattedString += ',';
            }

            if (returnFormattedString.Length > 0)
            {
                returnFormattedString += unformattedPath[idx];
            }

            return returnFormattedString;

        }
        public string generateKeyboardPath(string inputLine)
        {
            string returnValue = "";

            foreach (char inputChar in inputLine)
            {
                char normalizedInputChar = normalizeChar(inputChar);
                if (normalizedInputChar != '\0')
                {
                    if (normalizedInputChar == ' ')
                    {
                        returnValue += "S";
                    }
                    else
                    {
                        returnValue += generatePath(getKeyIndex(normalizedInputChar)) + "#";
                        setCurrentPosition(getKeyIndex(normalizedInputChar));
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input character ignored: " + inputChar);
                    //This logic branch should probably have something more robust and flexible than a simple console write
                    //perhaps it should write out an audit log, or better yet, leveral an auditing class that handled the implementation
                }
            }
            return formatPathString(returnValue);
        }

        public int getKeyIndex(char charKey)
        {
            return keyboardLayout[charKey];
        }

        private int currentPosition = 0;
        public int getCurrentPosition()
        {
            return currentPosition;
        }
        public void setCurrentPosition(int currPos)
        {
            currentPosition = currPos;
        }

        public void gotoHomePosition()
        {
            currentPosition = getHomePosition();
        }
        public string generatePath(int newPos)
        {
            // Takes the new positions as input then calculates the path between it and current position
            // Returns a string representation of the path to get to the new position, giving X (up/down) then Y (left, right) sequence

            int calcXCoordinate(int arrayPosition)
            {
                return (int)Math.Floor((decimal)arrayPosition / (decimal)getKeyboardWidth());
            }
            int calcYCoordinate(int arrayPosition)
            {
                return arrayPosition % getKeyboardWidth();
            }

            int xDelta = calcXCoordinate(newPos) - calcXCoordinate(getCurrentPosition());
            int yDelta = calcYCoordinate(newPos) - calcYCoordinate(getCurrentPosition());

            string returnValue = "";

            for (int i = 0; i < Math.Abs(xDelta); i++)
            {
                if (xDelta < 0)
                {
                    returnValue = returnValue + "U";
                }
                else
                {
                    returnValue = returnValue + "D";
                }
            }
            for (int i = 0; i < Math.Abs(yDelta); i++)
            {
                if (yDelta < 0)
                {
                    returnValue = returnValue + "L";
                }
                else
                {
                    returnValue = returnValue + "R";
                }
            }
            return returnValue;
        }
        public Keyboard()
        {
            currentPosition = getHomePosition();
        }

    }
}
