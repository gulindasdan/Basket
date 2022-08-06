namespace ProductService.Application.Queries.Product.Dto
{
    public record GetProductsResultDto 
    {
        public List<GetProductResultDto> Products { get; init; } = new ();
    }
}
