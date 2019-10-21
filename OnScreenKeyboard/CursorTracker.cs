using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace OnScreenKeyboard
{
    /*
        CursorTracker class
        Contains all methods for tracking cursor path and generating the cursor path script
        in a specified format.
    */
    /// <summary>
    /// <c>CursorTracker</c> class.
    /// Contains all methods for tracking cursor path and generating the cursor path script
    /// in a specified format.
    /// </summary>
    public static class CursorTracker
    {
        // default starting position of cursor on a keyboard ('A')
        static (int Row, int Col) cursorDefaultPosition = (0, 0);

        // allowed moves for cursor and their reserved script symbols
        const char moveUp = 'U';
        const char moveDown = 'D';
        const char moveLeft = 'L';
        const char moveRight = 'R';

        // reserved script symbols
        const char space = 'S';
        const char select = '#';
        const char separator = ',';

        /// <summary>
        /// Finds the cursor path on the keyboard for the search term string
        /// and generates cursor path script string in a specified format.
        /// </summary>
        /// <returns>
        /// Cursor path script string.
        /// </returns>
        /// <param name = "inputString" >Search term string.</param> 
        public static string GetCursorPathScript(string inputString)
        {
            inputString = inputString.ToUpper(CultureInfo.CurrentCulture);

            var cursorCurrentPosition = cursorDefaultPosition;
            var cursorPath = new List<char>();

            foreach (var character in inputString)
            {
                var cursorTargetPosition = Keyboard.GetKeyLocation(character);

                if (cursorTargetPosition == (-1, -1))
                {
                    cursorPath.Add(space);
                }
                else
                {
                    var pathBetweenKeys = GetPathBetweenKeys(cursorCurrentPosition, cursorTargetPosition);
                    cursorPath.AddRange(pathBetweenKeys);

                    cursorCurrentPosition = cursorTargetPosition;
                }

            }

            var cursorPathScript = string.Join(separator, cursorPath);

            return cursorPathScript;
        }

        /// <summary>
        /// Finds the cursor path between two keys.
        /// </summary>
        /// <returns>
        /// A list that contains elements which correspond to the sequence of cursor moves from one key to another.
        /// </returns>
        /// <param name = "currentKeyLocation" >Postion of key at which the cursor is currently located.</param> 
        /// <param name = "targetKeyLocation" >Postion of key to which the cursor needs to move.</param> 
        private static List<char> GetPathBetweenKeys((int Row, int Col) currentKeyLocation, (int Row, int Col) targetKeyLocation)
        {
            var path = new List<char>();

            var rowOffset = targetKeyLocation.Row - currentKeyLocation.Row;
            var colOffset = targetKeyLocation.Col - currentKeyLocation.Col;

            if (rowOffset != 0)
            {
                var moveDirection = GetMoveDirection(rowOffset, false);
                path.AddRange(Enumerable.Repeat(moveDirection, Math.Abs(rowOffset)).ToArray());
            }

            if (colOffset != 0)
            {
                var moveDirection = GetMoveDirection(colOffset, true);
                path.AddRange(Enumerable.Repeat(moveDirection, Math.Abs(colOffset)).ToArray());
            }

            path.Add(select);

            return path;
        }

        /// <summary>
        /// Finds cursor move direction either in row or in column.
        /// </summary>
        /// <returns>
        /// Move direction either in row or in column.
        /// </returns>
        /// <param name = "offset" >Row or column offset.</param> 
        /// <param name = "isMoveInRow" >Defines if cursor moves in row or in column.</param> 
        private static char GetMoveDirection(int offset, bool isMoveInRow)
        {
            var moveDirection = offset < 0 ?
                (isMoveInRow ? moveLeft : moveUp) :
                (isMoveInRow ? moveRight : moveDown);

            return moveDirection;
        }
    }
}
