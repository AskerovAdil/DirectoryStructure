using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract
{
    public interface ICatalogItemService
    {
        Task<IEnumerable<CatalogItem>> GetAllAsync();
        Task<CatalogItem> GetByIdAsync(int id);
        Task AddAsync(CatalogItem catalogItem);
        Task UpdateAsync(CatalogItem catalogItem);
        Task DeleteAsync(int id);
    }
}
