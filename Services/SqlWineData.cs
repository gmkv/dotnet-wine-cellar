using System.Collections.Generic;
using System.Linq;
using gm18119.Data;
using gm18119.Models;

namespace gm18119.Services
{
    // SqlWineData provides a way to modify the state of the DB. 
    // It holds the representation of the state of the DB in a field named context.
    public class SqlWineData : IWineData
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

        public Wine Edit(int id, Wine wine)
        {
            wine.Id = id;
            m_context.Update(wine);
            m_context.SaveChanges();
            return wine;
        }

        public Wine Get(int id)
        {
            return m_context.Wines.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Wine> GetAll()
        {
            return m_context.Wines.OrderByDescending(r => r.Id);
        }
    }
}