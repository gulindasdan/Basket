namespace BasketService.API.Models.Basket.Response;

public record BasketResponse
{
    public string BasketId { get; init; }
    public List<BasketItemResponse> Items { get; init; } = new List<BasketItemResponse>();
}
