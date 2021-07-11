using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Ninject;
using Ninject.Extensions.Logging;
using Ninject.Modules;
using AutoMapper;
namespace BaseLinker_Orders
{
    class Program
    {
        static StandardKernel _standardKernel = new StandardKernel(new NinjectBindings());


        static void Main(string[] args)
        {
            var orderService = _standardKernel.Get<OrderManagement>();
            // log4net logging
            log4net.Config.XmlConfigurator.Configure();


            var order = new Order();
            Task.Run(async () =>
            {
                order = await orderService.GetOrderAsync(7546601);
            }).GetAwaiter().GetResult();


            var orderCopy = order?.orders?.LastOrDefault();

            // duplicate order with additional properties
            var newOrder = CopyOrder(orderCopy);

            var response = new NewOrderStatus();
            Task.Run(async () =>
            {
                response = await orderService.AddOrderAsync(newOrder);
            }).GetAwaiter().GetResult();


            Console.ReadLine();

        }


        public static Order.AddOrder CopyOrder(Order.OrderDetails order)
        {
            var mapper = _standardKernel.Get<IMapper>();
            var copy = mapper.Map<Order.OrderDetails, Order.AddOrder>(order);

            // add comment
            copy.admin_comments = $"Zamówienie utworzone na podstawie {order.Order_id}";
            var bonusProduct = new Models.Product
            {
                name = "Gratis",
                price_brutto = 1.00f,
                quantity = 1
            };
            // add new product
            copy.products.Add(bonusProduct);

            return copy;
        }


    }
}
