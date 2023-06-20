using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace DataAccess.Entities
{
    public class CatalogItem
    {
        public CatalogItem(string name)
        {
            Name = name;
        }

        [Key]
        public int Id{ get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public CatalogItem ParentCatalog { get; set; }
        public List<CatalogItem>? SubCatalogs { get; set; }
    }
}