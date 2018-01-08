using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnScreenKey
{
    /// <summary>
    /// The factory class for DVR line processors.
    /// </summary>
    abstract class AbstractDVRLineProcessorFactory
    {
        /// <summary>
        /// The class's factory method.
        /// </summary>
        /// <returns>Returns an object which must implement the AbstractDVRLineProcessor interface.</returns>
        public abstract AbstractDVRLineProcessor getLineProcessor();
    }
}
