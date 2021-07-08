using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Ninject.Extensions.Logging;
//using Serilog;
namespace BaseLinker_Orders
{
    class OrderManagement : IOrderManagement
    {
        private const string BASEURL = "https://api.baselinker.com/connector.php";
        private const string TOKEN = "3001691-3007610-DPWWR5VEYII6EJB86LPZDCF72YZBQ5XEW4F84LJZLAWZP2NI4ROG7QM7LIJELN3T";


        public OrderManagement(ILogger logger)
        {
            _logger = logger;
        }
        public ILogger _logger { get; private set; }



        public async Task<NewOrderStatus> AddOrderAsync(Order.AddOrder order)
        {
            string method = "addOrder";
            NameValueCollection parameters = new NameValueCollection();
            try
            {
                var newOrderJson = JsonConvert.SerializeObject(order,Formatting.Indented);
                parameters.Add("parameters", newOrderJson);
                _logger.Info($"New order details: {newOrderJson}");
                string response = await GetResponse(method, parameters);
                var newOrder = JsonConvert.DeserializeObject<NewOrderStatus>(response);
                _logger.Info($"Creating new order status: {newOrder.status} with Id {newOrder.Order_Id}");
                return newOrder;
            }
            catch (Exception e)
            {
                _logger.Fatal(e, "Error creating new order");
                throw;
            }
        }

        public async Task<Order> GetOrdersAsync()
        {
            string method = "getOrders";
            _logger.Info("Downloading Orders");

            try
            {
                string response = await GetResponse(method, null);

                var orders = JsonConvert.DeserializeObject<Order>(response);

                if (orders.status == ResponseStatus.ERROR)
                {
                    _logger.Error($"BaseLinker error: {orders.error_code} - {orders.error_message}");

                }

                _logger.Info($"Downloading orders status: {orders.status}. Found [{orders.orders.Length}] orders");
                return orders;
            }
            catch (WebException e)
            {
                _logger.Fatal(e, "Error downloading orders");
                throw;
            }
        }

        private async Task<string> GetResponse(string method, NameValueCollection parameters)
        {
            try
            {
                string response;
                NameValueCollection values = GetRequiredParams(method);
                if (parameters != null || parameters?.Count > 0)
                {
                    values.Add(parameters);
                }
                byte[] bytes = null;
                using (var wc = new WebClient())
                {
                    bytes = await wc.UploadValuesTaskAsync(new Uri(BASEURL), "POST", values);
                }
                response = Encoding.UTF8.GetString(bytes);
                return response;
            }
            catch (Exception e)
            {
                _logger.Fatal(e, "Error getting response");
                throw;
            }
        }

        private NameValueCollection GetRequiredParams(string method)
        {
            var values = new NameValueCollection();
            values["token"] = TOKEN;
            values["method"] = method;
            return values;
        }
    }

    public static class ResponseStatus
    {
        public const string ERROR = "ERROR";
        public const string SUCCESS = "SUCCESS";
    }
}
