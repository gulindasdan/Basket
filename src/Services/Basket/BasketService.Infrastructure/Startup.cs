using BasketService.Application.Interfaces;
using BasketService.Application.Interfaces.ExternalServices.Product;
using BasketService.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BasketService.Infrastructure;

public static class Startup
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IBasketRepository, BasketRepository>();
        services.AddScoped<IProductService, ExternalServices.Product.ProductService>();
        services.Configure<RedisSettings>(configuration.GetSection(RedisSettings.Name));
        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = configuration.GetValue<string>("Redis:ConnectionString");
        });

        return services;
    }
}
