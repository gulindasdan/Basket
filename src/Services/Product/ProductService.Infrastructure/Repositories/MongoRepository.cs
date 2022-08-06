using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProductService.Application.Interfaces.Repositories;
using ProductService.Domain.Entities;
using System.Linq.Expressions;

namespace ProductService.Infrastructure.Repositories
{
    public class MongoRepository<T> : IRepository<T> where T : BaseEntity, new()
    {
        protected readonly IMongoCollection<T> collection;
        private readonly MongoDbSettings settings;

        public MongoRepository(IOptions<MongoDbSettings> options)
        {
            settings = options.Value;
            var client = new MongoClient(settings.ConnectionString);
            var db = client.GetDatabase(settings.Database);
            collection = db.GetCollection<T>(settings.ProductCollection);
        }

        public async Task<T> AddAsync(T entity)
        {
            var options = new InsertOneOptions { BypassDocumentValidation = false };
            await collection.InsertOneAsync(entity, options);
            return entity;
        }

        public async Task<bool> AddRangeAsync(IEnumerable<T> entities)
        {
            var options = new BulkWriteOptions { IsOrdered = false, BypassDocumentValidation = false };
            return (await collection.BulkWriteAsync((IEnumerable<WriteModel<T>>)entities, options)).IsAcknowledged;

        }

        public async Task<T> DeleteAsync(T entity)
        {
            return await collection.FindOneAndDeleteAsync(x => x.Id == entity.Id);
        }

        public async Task<T> DeleteAsync(string id)
        {
            return await collection.FindOneAndDeleteAsync(x => x.Id == id);
        }

        public async Task<T> DeleteAsync(Expression<Func<T, bool>> predicate)
        {
            return await collection.FindOneAndDeleteAsync(predicate);
        }

        public async Task<List<T>> GetAsync()
        {
            return await collection.Find(p=> true).ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await collection.Find(predicate).FirstOrDefaultAsync();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<T> UpdateAsync(string id, T entity)
        {
            return await collection.FindOneAndReplaceAsync(x => x.Id == id, entity);
        }

        public async Task<T> UpdateAsync(T entity, Expression<Func<T, bool>> predicate)
        {
            return await collection.FindOneAndReplaceAsync(predicate, entity);
        }
    }
}
