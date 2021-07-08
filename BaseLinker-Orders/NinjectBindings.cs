﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using Ninject;
using Ninject.Extensions.Logging;
using log4net;

namespace BaseLinker_Orders
{
    class NinjectBindings : NinjectModule
    {


        public override void Load()
        {
            Bind<ITest>().To<DTest>();
            Bind<IOrderManagement>().To<OrderManagement>();
            
        }
    }
}
