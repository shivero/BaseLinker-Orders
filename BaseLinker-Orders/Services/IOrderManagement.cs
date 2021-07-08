using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLinker_Orders
{
    interface IOrderManagement
    {
        Order GetOrders();
        NewOrderStatus AddOrder(Order.AddOrder orderList);
    }
}
