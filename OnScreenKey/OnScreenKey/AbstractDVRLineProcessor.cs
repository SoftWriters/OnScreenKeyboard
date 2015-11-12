using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnScreenKey
{
    /// <summary>
    /// The interface for DVR Line Processors. Demands one method, processLine.
    /// </summary>
    abstract class AbstractDVRLineProcessor
    {
        /// <summary>
        /// A function for processing a line of input into its equivalent in DVR navigation commands.
        /// </summary>
        /// <param name="inLine">The input line, in plaintext.</param>
        /// <returns>Returns a string of commands, or a blank line if no valid commands could be given based on the input string.</returns>
        public abstract String processLine(String inLine);
        
    }
}
