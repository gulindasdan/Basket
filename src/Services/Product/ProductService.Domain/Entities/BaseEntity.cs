namespace ProductService.Domain.Entities
{
    public abstract class BaseEntity
    {
        public string Id { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
