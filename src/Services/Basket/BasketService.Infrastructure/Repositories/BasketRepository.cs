using BasketService.Application.Interfaces;
using BasketService.Domain.Entities;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace BasketService.Infrastructure.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _redisCache;

        public BasketRepository(IDistributedCache cache)
        {
            _redisCache = cache ?? throw new ArgumentNullException(nameof(cache));
        }

        public async Task<Basket> GetBasket(string basketId, CancellationToken cancellationToken)
        {
            var basket = await _redisCache.GetStringAsync(basketId, cancellationToken);

            if (string.IsNullOrEmpty(basket))
                return new Basket(basketId);

            return JsonSerializer.Deserialize<Basket>(basket);
        }

        public async Task<Basket> UpdateBasket(Basket basket, CancellationToken cancellationToken)
        {
            await _redisCache.SetStringAsync(basket.BasketId, JsonSerializer.Serialize(basket), cancellationToken);
            
            return await GetBasket(basket.BasketId, cancellationToken);
        }

        public async Task DeleteBasket(string basketId, CancellationToken cancellationToken)
        {
            await _redisCache.RemoveAsync(basketId, cancellationToken);
        }
    }
}
