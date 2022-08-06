using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using ProductService.Domain.Entities;
using ProductService.Infrastructure.Repositories;

namespace ProductService.Infrastructure.Context
{
    public class ProductDbContextInitializer
    {
        private readonly IMongoCollection<Product> _productCollection;
        public ProductDbContextInitializer(IOptions<MongoDbSettings> mongoDBSettings)
        {
            var client = new MongoClient(mongoDBSettings.Value.ConnectionString);
            var database = client.GetDatabase(mongoDBSettings.Value.Database);

            _productCollection = database.GetCollection<Product>(mongoDBSettings.Value.ProductCollection);
        }

        public async Task Initialize()
        {
            bool existProduct = await _productCollection.Find(p => true).AnyAsync();
            if (!existProduct)
            {
                await _productCollection.InsertManyAsync(GetPreconfiguredProducts());
            }
        }

        private static IEnumerable<Product> GetPreconfiguredProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Name = "Apple",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    Price = 50.00M,
                    Quantity = 8,
                    Image = "image.png",
                    Link = "link",
                    VariantId = ObjectId.GenerateNewId().ToString(),
                    CreatedOn = DateTime.UtcNow
                },
                new Product()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Name = "Orange",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    Price = 20.00M,
                    Quantity = 5,
                    Image = "image.png",
                    Link = "link",
                    VariantId = ObjectId.GenerateNewId().ToString(),
                    CreatedOn = DateTime.UtcNow
                },
                new Product()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Name = "Banana",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    Price = 30.00M,
                    Quantity = 2,
                    Image = "image.png",
                    Link = "link",
                    VariantId = ObjectId.GenerateNewId().ToString(),
                    CreatedOn = DateTime.UtcNow
                },
                new Product()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Name = "Grape",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    Price = 80.00M,
                    Quantity = 20,
                    Image = "image.png",
                    Link = "link",
                    VariantId = ObjectId.GenerateNewId().ToString(),
                    CreatedOn = DateTime.UtcNow
                },
                new Product()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Name = "Strawberry",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    Price = 100.00M,
                    Quantity = 6,
                    Image = "image.png",
                    Link = "link",
                    VariantId = ObjectId.GenerateNewId().ToString(),
                    CreatedOn = DateTime.UtcNow
                }
            };
        }
    }
}
