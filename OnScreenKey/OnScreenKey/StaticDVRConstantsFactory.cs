using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnScreenKey
{
    /// <summary>
    /// The factory for the reference implementation of the DVR Constants interface, StaticDVRConstants
    /// </summary>
    class StaticDVRConstantsFactory : AbstractDVRConstantsFactory
    {
        /// <summary>
        /// The factory method.
        /// </summary>
        /// <returns>Returns an instance of StaticDVRConstants, the AbstractDVRConstants reference implementation.</returns>
        public override AbstractDVRConstants getDVRConstants()
        {
            return new StaticDVRConstants();
        }
    }
}
