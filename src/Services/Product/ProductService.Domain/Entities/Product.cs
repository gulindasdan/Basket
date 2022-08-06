namespace ProductService.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string VariantId { get; set; }
        public string Link { get; set; }
        public string Image { get; set; }
    }
}
