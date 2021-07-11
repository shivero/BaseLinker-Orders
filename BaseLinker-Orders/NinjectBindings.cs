using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using Ninject;
using Ninject.Extensions.Logging;
using log4net;
using AutoMapper;
namespace BaseLinker_Orders
{
    class NinjectBindings : NinjectModule
    {


        public override void Load()
        {
            var mapperConfiguration = CreateConfiguration();
            Bind<MapperConfiguration>().ToConstant(mapperConfiguration).InSingletonScope();

            Bind<IMapper>().ToMethod(context => new Mapper(mapperConfiguration, type => context.Kernel.Get(type)));

            Bind<IOrderManagement>().To<OrderManagement>();

        }

        private MapperConfiguration CreateConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
           {
               cfg.CreateMap<Order.OrderDetails, Order.AddOrder>();

               cfg.AddMaps(GetType().Assembly);
           });
            return config;
        }
    }
}
