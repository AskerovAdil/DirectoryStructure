using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICatalogItemRepository
    {
        Task<IEnumerable<CatalogItem>> GetAllAsync();
        Task<CatalogItem> GetByIdAsync(int id);
        Task<CatalogItem> GetByNameAsync(string name);
        Task AddAsync(CatalogItem catalogItem);
        Task UpdateAsync(CatalogItem catalogItem);
        Task DeleteAsync(CatalogItem catalogItem);
    }
}
