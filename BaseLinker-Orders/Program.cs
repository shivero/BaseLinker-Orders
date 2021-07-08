using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Ninject;
using Ninject.Modules;

namespace BaseLinker_Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            StandardKernel _standardKernel = new StandardKernel(new NinjectBindings());

            var orderService = _standardKernel.Get<OrderManagement>();

            var order = orderService.GetOrders();
                
            if (order.orders != null)
            {
                Console.WriteLine($"Znaleziono {order.orders.Length} zamówień");
            }
            Console.WriteLine(JsonConvert.SerializeObject(order, Formatting.Indented));



            var newOrder = new Order.AddOrder();
            newOrder.order_status_id = 50690;
            newOrder.date_add = DateTimeOffset.Now.ToUnixTimeSeconds();
            newOrder.admin_comments = "test";
            var response = orderService.AddOrder(newOrder);

            Console.WriteLine("nowe zamówienie" + JsonConvert.SerializeObject(response));
            
            Console.ReadLine();

        }
    }
}
