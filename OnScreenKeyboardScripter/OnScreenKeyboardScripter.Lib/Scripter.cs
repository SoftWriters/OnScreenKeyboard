using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnScreenKeyboardScripter.Lib
{
    /// <summary>
    /// Translates keyboard cursor movements and DVR actions into comma-separated "action" sequence of characters
    /// </summary>
    /// <seealso cref="OnScreenKeyboardScripter.Lib.IScripter" />
    public class Scripter : IScripter
    {
        /// <summary>
        /// Gets the comma-separated "action" sequence of characters from 
        /// </summary>
        /// <param name="keyboard">The on-screen keyboard representation</param>
        /// <param name="input">The text input to translate</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public string GetPath(IKeyboard keyboard, string input)
        {
            List<char> path = new List<char>();

            if (keyboard == null)
            {
                throw new ArgumentNullException();
            }

            if (!string.IsNullOrEmpty(input))
            {
                char lastkey = 'A';
                foreach(var nextkey in input.ToUpper())
                {
                    if (nextkey == ' ')
                    {
                        path.Add('S');
                    }
                    else
                    {
                        var cursorPath = keyboard.GetCursorPath(lastkey, nextkey)
                                                 .Select(mc => Enum.GetName(typeof(MoveCursor), mc)[0])
                                                 .ToArray();
                        if (cursorPath.Length > 0)
                        {
                            path.AddRange(cursorPath);
                            path.Add('#');
                        }
                        lastkey = nextkey;
                    }
                }
            }

            return string.Join(",", path);
        }
    }
}
