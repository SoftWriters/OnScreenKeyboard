using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnScreenKeyboardScripter.Lib
{
    public enum MoveCursor
    {
        Up,
        Down,
        Left,
        Right
    }

    public interface IKeyboard
    {
        List<MoveCursor> GetCursorPath(char fromKey, char toKey);
    }
}
