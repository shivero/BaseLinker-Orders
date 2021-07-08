using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLinker_Orders
{
    interface IOrderManagement
    {
        Task<Order> GetOrdersAsync();
        Task<NewOrderStatus> AddOrderAsync(Order.AddOrder orderList);
    }
}
