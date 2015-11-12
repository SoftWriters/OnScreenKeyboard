using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnScreenKey
{
    /// <summary>
    /// A factory class for producing instances of a DVR Constants class. Implements one method, getDVRConstants.
    /// </summary>
    abstract class AbstractDVRConstantsFactory
    {
        /// <summary>
        /// The class's factory method.
        /// </summary>
        /// <returns>Returns an object which must implement the AbstractDVRConstants interface.</returns>
        public abstract AbstractDVRConstants getDVRConstants();
    }
}
