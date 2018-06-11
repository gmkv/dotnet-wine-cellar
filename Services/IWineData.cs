using System.Collections.Generic;
using gm18119.Models;

namespace gm18119.Services
{
    public interface IWineData
    {
        IEnumerable<Wine> GetAllWines();
        Wine Get(int id);
        Wine Add(Wine wine);
        Wine Edit(int id, Wine wine);
        void Delete(int id);
    }
}