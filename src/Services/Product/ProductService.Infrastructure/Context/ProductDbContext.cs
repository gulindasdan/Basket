using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProductService.Application.Interfaces.Context;
using ProductService.Domain.Entities;
using ProductService.Infrastructure.Repositories;

namespace ProductService.Infrastructure.Context
{
    public class ProductDbContext : IProductDbContext
    {
        public ProductDbContext(IConfiguration configuration, IOptions<MongoDbSettings> mongoDBSettings)
        {
            
        }

        public IMongoCollection<Product> Products { get; }
    }
}
