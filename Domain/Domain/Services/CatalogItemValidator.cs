using DataAccess.Entities;
using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class CatalogItemValidator : ICatalogItemValidator
    {
        public void Validate(CatalogItem catalogItem)
        {
            
            if (catalogItem == null)
                throw new ArgumentNullException(nameof(catalogItem));

            if (string.IsNullOrEmpty(catalogItem.Name))
                throw new ArgumentException("Name is required", nameof(catalogItem));
        }
    }
}
