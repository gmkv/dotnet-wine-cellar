using System.Collections.Generic;
using gm18119.Models;

namespace gm18119.Services
{
    public interface IOrderData
    {
        IEnumerable<Order> GetAllOrders(); // won't be fun to load 100 000 orders
        void Process(Order order);

        Order GetOrder(int id);
    }
}