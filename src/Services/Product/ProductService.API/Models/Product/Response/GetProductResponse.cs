namespace ProductService.API.Models.Product.Response
{
    public record GetProductResponse
    {
        public string Id { get; init; }
        public DateTime CreatedOn { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public decimal Price { get; init; }
        public int Quantity { get; init; }
        public string VariantId { get; init; }
        public string Link { get; init; }
        public string Image { get; init; }
    }
}
