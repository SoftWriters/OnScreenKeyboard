using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnScreenKey
{
    /// <summary>
    /// The interface prototype, implementing all DVR constants -- ways of mapping the directions to an output text file.
    /// </summary>
    /// <remarks>Demands the following seven read-only properties: Left, Right, Up, Down, Space, Enter, and Separator, all of which return strings.
    /// The reference implementation is in StaticDVRConstants.</remarks>
    abstract class AbstractDVRConstants
    {
        
        public abstract String Left { get; }
        public abstract String Right { get; }
        public abstract String Up { get; }
        public abstract String Down { get; }
        public abstract String Space { get; }
        public abstract String Enter { get; }
        public abstract String Separator { get; }

    }
}
