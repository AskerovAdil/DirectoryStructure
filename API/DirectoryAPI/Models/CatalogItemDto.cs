namespace DirectoryAPI.Models
{
    public class CatalogItemDto
    {
        public CatalogItemDto(string name) { 
            this.Name = name;
        }
        public string Name { get; set; }
        public int? ParentId { get; set; }
    }
}
