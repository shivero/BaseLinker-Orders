using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace BaseLinker_Orders
{
    class OrderManagement : IOrderManagement
    {
        private string baseUrl = "https://api.baselinker.com/connector.php";
        private string token = "3001691-3007610-DPWWR5VEYII6EJB86LPZDCF72YZBQ5XEW4F84LJZLAWZP2NI4ROG7QM7LIJELN3T";



        public NewOrderStatus AddOrder(Order.AddOrder order)
        {
            string method = "addOrder";

            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("parameters", JsonConvert.SerializeObject(order));

            string response = string.Empty;
            using (var wc = new WebClient())
            {
                response = GetResponse(method, wc, parameters);
            }
            var res = JsonConvert.DeserializeObject<Order>(response);
            return new NewOrderStatus();
        }

        public Order GetOrders()
        {
            string method = "getOrder";
            string response = string.Empty;
            using (var wc = new WebClient())
            {
                response = GetResponse(method, wc, null);
            }
            if (string.IsNullOrEmpty(response))
            {
                throw new ArgumentException($"Response from method {method} is null", nameof(response));
            }
            var order = JsonConvert.DeserializeObject<Order>(response);
            if (order.status == ResponseStatus.ERROR)
            {
                Console.WriteLine($"BaseLinker response error: {order.error_code} - {order.error_message}");
            }
            return order;
        }

        private string GetResponse(string method, WebClient wc, NameValueCollection parameters)
        {
            string response;
            NameValueCollection values = GetRequiredParams(method);
            if (parameters != null || parameters?.Count > 0)
            {
                values.Add(parameters);
            }
            byte[] bytes = wc.UploadValues(baseUrl, "POST", values);
            response = Encoding.UTF8.GetString(bytes);
            return response;
        }

        private NameValueCollection GetRequiredParams(string method)
        {
            var values = new NameValueCollection();
            values["token"] = token;
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
