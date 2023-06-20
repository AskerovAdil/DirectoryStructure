using DataAccess.Entities;

namespace Domain.Services
{
    public interface ICatalogItemValidator
    {
        void Validate(CatalogItem catalogItem);
    }

}