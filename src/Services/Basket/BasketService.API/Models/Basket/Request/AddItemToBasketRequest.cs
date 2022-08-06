namespace BasketService.API.Models.Basket.Request;

public record AddItemToBasketRequest
{
    public string ProductId { get; init; }
    public int Quantity { get; init; }
}
