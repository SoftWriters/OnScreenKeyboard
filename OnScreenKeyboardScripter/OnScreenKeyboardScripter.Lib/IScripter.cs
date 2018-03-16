using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnScreenKeyboardScripter.Lib
{
    public interface IScripter
    {
        string GetPath(IKeyboard keyboard, string input);
    }
}
