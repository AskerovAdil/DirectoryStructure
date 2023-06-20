using DataAccess.Entities;

namespace Domain.Abstract
{
    public interface ICatalogItemValidator
    {
        void Validate(CatalogItem catalogItem);
    }

}