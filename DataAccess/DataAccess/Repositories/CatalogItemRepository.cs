using DataAccess.Abstract;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class CatalogItemRepository : ICatalogItemRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CatalogItemRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CatalogItem>> GetAllAsync()
        {
            var catalogItems = await _dbContext.CatalogItems.ToListAsync();
            if (catalogItems == null)
                throw new Exception("Catalog items not found");

            return catalogItems;
        }

        public async Task<CatalogItem> GetByIdAsync(int id)
        {
            var catalogItem = await _dbContext.CatalogItems.FindAsync(id);
            if (catalogItem == null)
                throw new Exception("Catalog item not found");

            return catalogItem;
        }

        public async Task<CatalogItem> GetByNameAsync(string name)
        {
            var catalogItem = await _dbContext.CatalogItems.FirstOrDefaultAsync(x => x.Name == name);
            if (catalogItem == null)
                throw new Exception("Catalog item not found");

            return catalogItem;
        }

        public async Task AddAsync(CatalogItem catalogItem)
        {
            if (catalogItem == null)
                throw new ArgumentNullException(nameof(catalogItem));

            await _dbContext.CatalogItems.AddAsync(catalogItem);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(CatalogItem catalogItem)
        {
            if (catalogItem == null)
                throw new ArgumentNullException(nameof(catalogItem));

            _dbContext.Entry(catalogItem).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(CatalogItem catalogItem)
        {
            if (catalogItem == null)
                throw new ArgumentNullException(nameof(catalogItem));

            _dbContext.CatalogItems.Remove(catalogItem);
            await _dbContext.SaveChangesAsync();
        }



    }
}
