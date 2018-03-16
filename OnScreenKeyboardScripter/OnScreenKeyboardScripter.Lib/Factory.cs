using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnScreenKeyboardScripter.Lib
{
    /// <summary>
    /// Single source for keyboards and scripters
    /// </summary>
    public sealed class Factory
    {
        static StructureMap.IContainer container = null;

        /// <summary>
        /// Gets the currently-registered <see cref="Keyboard"/> class.
        /// </summary>
        /// <returns><see cref="IKeyboard"/></returns>
        static public IKeyboard GetKeyboard() { return container.GetInstance<IKeyboard>(); }
        /// <summary>
        /// Gets the currently-registered <see cref="Scripter"/> class.
        /// </summary>
        /// <returns><see cref="IScripter"/></returns>
        static public IScripter GetScripter() { return container.GetInstance<IScripter>(); }

        /// <summary>
        /// Initializes the <see cref="Factory"/> class.
        /// </summary>
        static Factory()
        {
            container = new StructureMap.Container(cfg =>
            {
                cfg.For<IKeyboard>().Use<Keyboard>();
                cfg.For<IScripter>().Use<Scripter>();
            });
        }
    }
}
