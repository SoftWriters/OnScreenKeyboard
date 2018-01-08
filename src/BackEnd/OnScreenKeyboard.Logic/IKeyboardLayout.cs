using System;
using System.Collections.Generic;
using System.Text;

namespace OnScreenKeyboard.Logic
{
    public interface IKeyboardLayout
    {
        KeyLocation? GetKeyLocation(char key);
    }
}
