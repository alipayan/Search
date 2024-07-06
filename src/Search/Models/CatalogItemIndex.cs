namespace Search.Models
{
    public class CatalogItemIndex
    {
        public const string IndexName = "catalog-item-index";
        public string Name { get; set; }
        public string Description { get; set; }
        public string CatalogCategory { get; set; }
        public string CatalogBrand { get; set; }
        public string Slug { get; set; }
        public string hintUrl { get; set; }
    }
}
