using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnScreenKeyboard.Exceptions
{
    public class LetterNotMappedException : Exception
    {

        public char Letter { get; set; }

    }  // end class
}  // end namespace
