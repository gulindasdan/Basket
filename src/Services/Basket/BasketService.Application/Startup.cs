using BasketService.Application.Interfaces.ExternalServices.Product;
using BasketService.Application.Validators;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductService.Application.Behaviors;
using System.Reflection;

namespace BasketService.Application;

public static class Startup
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.Configure<ProductServiceSettings>(configuration.GetSection(nameof(ProductServiceSettings)));   
        services.AddValidatorsFromAssembly(typeof(AddItemToBasketCommandValidator).Assembly);
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        return services;
    }
}
