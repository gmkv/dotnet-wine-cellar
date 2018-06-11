using System.Collections.Generic;
using gm18119.Models;

namespace gm18119.Services
{
    public interface IOrderData
    {
        IEnumerable<Order> GetAllOrders();
        Order GetOrder(int id);
        Order UpdateStatus(int id, OrderStatus newStatus);
        Order Add(Order model);
    }
}