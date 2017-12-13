using System;
using System.Collections.Generic;
using System.Text;

namespace KeyboardInterface
{
    public interface IScreenKeyboard
    {
        string StringToKeyboard(string inputString);
        string KeyboardToString(string inputKeyboardCode);
    }
}
