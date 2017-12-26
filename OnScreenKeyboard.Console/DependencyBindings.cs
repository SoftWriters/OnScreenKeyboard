using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using OnScreenKeyboard.Keyboards;

namespace OnScreenKeyboard.ConsoleProgram
{
    public class DependencyBindings : Ninject.Modules.NinjectModule
    {

        public override void Load()
        {

            //todo: use appSettings to map the binding so we can change the bindings without recompiling
            Bind<IKeyboard>().To<Example>().InTransientScope();
        }

    }  // end class
}  // end namespace
