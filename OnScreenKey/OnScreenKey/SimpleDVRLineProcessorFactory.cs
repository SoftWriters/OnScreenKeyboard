using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnScreenKey
{
    /// <summary>
    /// The reference implementation of the DVR Line Processor interface. Uses the DVR Constants type to map its output.
    /// </summary>
    class SimpleDVRLineProcessorFactory : AbstractDVRLineProcessorFactory
    {
        /// <summary>
        /// The factory method.
        /// </summary>
        /// <returns>Returns a simple DVR line processor, initialized to use the reference implementation of DVR Constants.</returns>
        public override AbstractDVRLineProcessor getLineProcessor()
        {
            var dcFactory = new StaticDVRConstantsFactory();
            AbstractDVRConstants dConst = dcFactory.getDVRConstants();

            return new SimpleDVRLineProcessor(dConst);
        }
    }
}
