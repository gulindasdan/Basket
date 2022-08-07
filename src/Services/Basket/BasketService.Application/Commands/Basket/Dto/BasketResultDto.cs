namespace BasketService.Application.Commands.Basket.Dto;

public record BasketResultDto
{
    public decimal TotalPrice { get; init; }
    public List<BasketItemResultDto> Items { get; init; } = new List<BasketItemResultDto>();
}