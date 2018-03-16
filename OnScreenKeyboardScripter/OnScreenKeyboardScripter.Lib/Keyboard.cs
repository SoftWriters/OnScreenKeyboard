using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnScreenKeyboardScripter.Lib
{
    /// <summary>
    /// Represents the on-screen keyboard layout and cursor-movement behavior.
    /// </summary>
    /// <seealso cref="OnScreenKeyboardScripter.Lib.IKeyboard" />
    public class Keyboard : IKeyboard
    {
        public bool CursorWrapsHorizontally { get; set; } = true;
        public bool CursorWrapsVertically { get; set; } = true;

        const int rowWidth = 6;
        const int rows = 6;

        const string layout =
            "ABCDEF" +
            "GHIJKL" +
            "MNOPQR" +
            "STUVWX" +
            "YZ0123" +
            "456789";

        /// <summary>
        /// Gets the cursor path from current key-location on keyboard to next key-location
        /// </summary>
        /// <param name="fromKey">Starting key (cursor position) on keyboard</param>
        /// <param name="toKey">Destination key (cursor position) on keyboard</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException">Unrecognized keyboard key</exception>
        public List<MoveCursor> GetCursorPath(char fromKey, char toKey)
        {
            int idxFrom = layout.IndexOf(fromKey),
                idxTo = layout.IndexOf(toKey);

            if (idxFrom < 0 || idxTo < 0)
            {
                throw new NotImplementedException("Unrecognized keyboard key");
            }

            List<MoveCursor> cursorMovements = new List<MoveCursor>();

            int fromY = (int)Math.Floor((double)idxFrom / (double)rowWidth),
                fromX = idxFrom - (fromY * rowWidth),
                toY = (int)Math.Floor((double)idxTo / (double)rowWidth),
                toX = idxTo - (toY * rowWidth);

            while (fromKey != toKey)
            {
                // go up instead of down if wrapping?
                var upOverDown = (CursorWrapsVertically && ((fromY + rows - toY) < toY - fromY));
                // go down instead of up if wrapping?
                var downOverUp = (CursorWrapsVertically && (toY + rows - fromY) < fromY - toY);
                // go left instead of right if wrapping
                var leftOverRight = (CursorWrapsHorizontally && ((fromX + rowWidth - toX) < toX - fromX));
                // go right instead of left if wrapping
                var rightOverLeft = (CursorWrapsHorizontally && ((toX + rowWidth - fromX) < fromX - toX));

                if ((toY < fromY && !downOverUp) || upOverDown)
                {
                    cursorMovements.Add(MoveCursor.Up);
                    fromY = (fromY + rows - 1) % rows;
                }
                // go down?
                else if (fromY < toY || downOverUp)
                {
                    cursorMovements.Add(MoveCursor.Down);
                    fromY = (fromY + 1) % rows;
                }
                // go left? toX < fromX
                else if ((fromX > toX && !rightOverLeft) || leftOverRight)
                {
                    cursorMovements.Add(MoveCursor.Left);
                    fromX = (fromX + rowWidth - 1) % rowWidth;
                }
                // go right? toX > fromX
                else if ((toX > fromX) || rightOverLeft)
                {
                    cursorMovements.Add(MoveCursor.Right);
                    fromX = (fromX + 1) % rowWidth;
                }

                fromKey = layout[(fromY * rowWidth) + fromX];
            }

            return cursorMovements;
        }
    }
}
