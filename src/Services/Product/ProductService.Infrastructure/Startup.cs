using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductService.Application.Interfaces.Context;
using ProductService.Application.Interfaces.Repositories;
using ProductService.Infrastructure.Context;
using ProductService.Infrastructure.Repositories;

namespace ProductService.Infrastructure;

public static class Startup
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ProductDbContextInitializer>();
        services.AddScoped(typeof(IRepository<>), typeof(MongoRepository<>));
        //services.AddScoped<IProductDbContext, ProductDbContext>();
        services.Configure<MongoDbSettings>(configuration.GetSection(MongoDbSettings.Name));
        
        return services;
    }
}
