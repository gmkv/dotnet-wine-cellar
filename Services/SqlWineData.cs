using System.Collections.Generic;
using System.Linq;
using gm18119.Data;
using gm18119.Models;

namespace gm18119.Services
{
    // SqlWineData provides a way to modify the state of the DB. 
    // It holds the representation of the state of the DB in a field named context.
    public class SqlWineData : IWineData, IOrderData
    {
        private WineDbContext m_context;

        public SqlWineData(WineDbContext context)
        {
            m_context = context;
        }
        public Wine Add(Wine wine)
        {
            m_context.Wines.Add(wine);
            // commit changes to DB
            m_context.SaveChanges();
            return wine;
        }

        public void Delete(int id)
        {
            Wine wine = Get(id);
            m_context.Remove(wine);
            m_context.SaveChanges();
        }

        public Wine Edit(int id, Wine changedWine)
        {
            changedWine.Id = id;
            m_context.Update(changedWine);
            m_context.SaveChanges();
            return changedWine;
        }

        public Wine Get(int id)
        {
            return m_context.Wines.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Wine> GetAllWines()
        {
            return m_context.Wines.OrderByDescending(r => r.Id);
        }

        public void Process(Order order)
        {
            // get order by Id, then change it's state to mark it as paid, cancelled, etc.
            // var o = m_context.Orders.FirstOrDefault(r => r.Id == order.Id);
            m_context.Orders.Update(order);
            m_context.SaveChanges();            
            }

        public IEnumerable<Order> GetAllOrders()
        {
            return m_context.Orders.OrderByDescending(o => o.Id);
        }

        public Order GetOrder(int id)
        {
            return m_context.Orders.FirstOrDefault(o => o.Id == id);
        }
    }
}