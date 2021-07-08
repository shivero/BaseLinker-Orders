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

            var orderCopy = order?.orders?.LastOrDefault();
            if (orderCopy == null)
            {
                Console.WriteLine("Brak zamówienia do skopiowania");
            }

            var newOrder = new Order.AddOrder()
            {
                admin_comments = $"Zamówienie utworzone na podstawie {orderCopy.order_id}",
                currency = orderCopy.currency,
                date_add = DateTimeOffset.Now.ToUnixTimeSeconds(),
                delivery_address = orderCopy.delivery_address,
                delivery_city = orderCopy.delivery_city,
                delivery_company = orderCopy.delivery_company,
                delivery_country_code = orderCopy.delivery_company,
                delivery_fullname = orderCopy.delivery_fullname,
                delivery_method = orderCopy.delivery_method,
                delivery_point_address = orderCopy.delivery_point_address,
                delivery_point_city = orderCopy.delivery_point_city,
                delivery_point_id = orderCopy.delivery_point_id,
                delivery_point_name = orderCopy.delivery_point_name,
                delivery_point_postcode = orderCopy.delivery_point_postcode,
                delivery_postcode = orderCopy.delivery_postcode,
                delivery_price = orderCopy.delivery_price,
                email = orderCopy.email,
                extra_field_1 = orderCopy.extra_field_1,
                extra_field_2 = orderCopy.extra_field_2,
                invoice_address = orderCopy.invoice_address,
                invoice_city = orderCopy.invoice_city,
                invoice_company = orderCopy.invoice_company,
                invoice_country_code = orderCopy.invoice_county_code,
                invoice_fullname = orderCopy.invoice_fullname,
                invoice_nip = orderCopy.invoice_nip,
                invoice_postcode = orderCopy.invoice_postcode,
                order_status_id = orderCopy.order_status_id,
                paid = orderCopy.paid,
                payment_method = orderCopy.payment_method,
                payment_method_cod = orderCopy.payment_method_cod,
                phone = orderCopy.phone,
                user_comments = orderCopy.user_comments,
                user_login = orderCopy.user_login,
                want_invoice = orderCopy.want_invoice,
                products = orderCopy?.products?.Append(new Models.Product
                {
                    name = "Gratis",
                    price_brutto = 1.00f
                }).ToArray()
            };

            var response = orderService.AddOrder(newOrder);

            Console.WriteLine("nowe zamówienie" + JsonConvert.SerializeObject(response));

            Console.ReadLine();

        }
    }
}
