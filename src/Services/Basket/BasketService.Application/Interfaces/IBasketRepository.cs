using BasketService.Domain.Entities;

namespace BasketService.Application.Interfaces;

public interface IBasketRepository
{
    Task<Basket> GetBasket(string basketId, CancellationToken cancellationToken);
    Task<Basket> UpdateBasket(Basket basket, CancellationToken cancellationToken);
}
