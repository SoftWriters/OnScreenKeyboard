using System;
using System.Collections.Generic;
using System.Text;

namespace OnScreenKeyboard
{
    public interface IScreenKeyboard
    {
        /// <summary>
        /// Function converts input string to DVR ketboard codes.
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns>The string of DVR ketboard codes</returns>
        string StringToKeyboard(string inputString);

        /// <summary>
        /// Funtion converts keyboard sequence codes to original string
        /// </summary>
        /// <param name="inputKeyboardCode"></param>
        /// <returns>The original string</returns>
        string KeyboardToString(string inputKeyboardCode);
    }
}
