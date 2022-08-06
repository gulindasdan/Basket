namespace BasketService.Application.Commands.Basket.Dto;

public record BasketResultDto
{
    public List<BasketItemResultDto> Items { get; init; } = new List<BasketItemResultDto>();
}