using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Ninject;
using Ninject.Extensions.Logging;
using Ninject.Modules;

namespace BaseLinker_Orders
{
    class Program
    {

        static void Main(string[] args)
        {
            StandardKernel _standardKernel = new StandardKernel(new NinjectBindings());
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
            var copy = new Order.AddOrder()
            {
                admin_comments = $"Zamówienie utworzone na podstawie {order.Order_id}",
                currency = order.Currency,
                date_add = DateTimeOffset.Now.ToUnixTimeSeconds(),
                delivery_address = order.Delivery_address,
                delivery_city = order.Delivery_city,
                delivery_company = order.Delivery_company,
                delivery_country_code = order.Delivery_company,
                delivery_fullname = order.Delivery_fullname,
                delivery_method = order.Delivery_method,
                delivery_point_address = order.Delivery_point_address,
                delivery_point_city = order.Delivery_point_city,
                delivery_point_id = order.Delivery_point_id,
                delivery_point_name = order.Delivery_point_name,
                delivery_point_postcode = order.Delivery_point_postcode,
                delivery_postcode = order.Delivery_postcode,
                delivery_price = order.Delivery_price,
                email = order.Email,
                extra_field_1 = order.Extra_field_1,
                extra_field_2 = order.Extra_field_2,
                invoice_address = order.Invoice_address,
                invoice_city = order.Invoice_city,
                invoice_company = order.Invoice_company,
                invoice_country_code = order.Invoice_county_code,
                invoice_fullname = order.Invoice_fullname,
                invoice_nip = order.Invoice_nip,
                invoice_postcode = order.Invoice_postcode,
                order_status_id = order.Order_status_id,
                paid = order.Paid,
                payment_method = order.Payment_method,
                payment_method_cod = order.Payment_method_cod,
                phone = order.Phone,
                user_comments = order.User_comments,
                user_login = order.User_login,
                want_invoice = order.Want_invoice,
                products = order?.Products?.Append(new Models.Product
                {
                    name = "Gratis",
                    price_brutto = 1.00f,
                    quantity = 1
                }).ToArray()
            };
            return copy;
        }


    }
}
