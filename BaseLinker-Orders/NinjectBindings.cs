using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using Ninject;
namespace BaseLinker_Orders
{
    class NinjectBindings : NinjectModule
    {


        public override void Load()
        {
            Bind<ITest>().To<DTest>();
        }
    }
}
