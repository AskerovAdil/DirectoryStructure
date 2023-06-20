using System.ComponentModel.DataAnnotations;

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
        public List<CatalogItem>? SubCatalogs { get; set; }
    }
}