using MongoDB.Driver;
using ProductService.Domain.Entities;

namespace ProductService.Application.Interfaces.Context
{
    public interface IProductDbContext
    {
        IMongoCollection<Product> Products { get; }
    }
}
