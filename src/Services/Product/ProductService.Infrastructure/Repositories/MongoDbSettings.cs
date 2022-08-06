namespace ProductService.Infrastructure.Repositories
{
    public class MongoDbSettings
    {
        public const string Name = "MongoDb";
        public string ProductCollection { get; set; }
        public string ConnectionString { get; set; }
        public string Database { get; set; }
    }
}
