namespace BasketService.API.Models.Basket.Response;

public record BasketItemResponse
{
    public int Quantity { get; init; }
    public string Image { get; init; }
    public string Link { get; init; }
    public decimal Price { get; init; }
    public string ProductId { get; init; }
    public string ProductName { get; init; }
}
