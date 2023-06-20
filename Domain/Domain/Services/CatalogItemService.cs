using DataAccess.Abstract;
using DataAccess.Entities;
using DataAccess.Repositories;
using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class CatalogItemService : ICatalogItemService
    {
        private readonly ICatalogItemRepository _catalogItemRepository;
        private readonly ICatalogItemValidator _catalogItemValidator;

        public CatalogItemService(ICatalogItemRepository catalogItemRepository, ICatalogItemValidator catalogItemValidator)
        {
            _catalogItemRepository = catalogItemRepository;
            _catalogItemValidator = catalogItemValidator;
        }

        public async Task<IEnumerable<CatalogItem>> GetAllAsync()
        {
            return await _catalogItemRepository.GetAllAsync();
        }

        public async Task<CatalogItem> GetByIdAsync(int id)
        {
            return await _catalogItemRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(CatalogItem catalogItem)
        {
            _catalogItemValidator.Validate(catalogItem);


            if (catalogItem.ParentId != null)
            {
                var parent= await _catalogItemRepository.GetByIdAsync(catalogItem.ParentId.Value);
                catalogItem.ParentCatalog = parent;
            }

            await _catalogItemRepository.AddAsync(catalogItem);
        }

        public async Task UpdateAsync(CatalogItem catalogItem)
        {

            var existingCatalogItem = await _catalogItemRepository.GetByIdAsync(catalogItem.Id);
            if (existingCatalogItem == null)
            {
                throw new InvalidOperationException("Catalog item not found");
            }

            _catalogItemValidator.Validate(catalogItem);

            existingCatalogItem.Name = catalogItem.Name;
            existingCatalogItem.ParentId = catalogItem.ParentId;

            _catalogItemValidator.Validate(existingCatalogItem);

            await _catalogItemRepository.UpdateAsync(existingCatalogItem);
        }

        public async Task DeleteAsync(int id)
        {
            var existingCatalogItem = await _catalogItemRepository.GetByIdAsync(id);
            if (existingCatalogItem == null)
            {
                throw new InvalidOperationException("Catalog item not found");
            }

            await _catalogItemRepository.DeleteAsync(existingCatalogItem);
        }
    }
}

