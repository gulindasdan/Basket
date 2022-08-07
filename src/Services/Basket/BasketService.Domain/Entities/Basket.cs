namespace BasketService.Domain.Entities;

public class Basket
{
    public Basket(string basketId)
    {
        BasketId = basketId;
    }

    public string BasketId { get; set; }
    public decimal TotalPrice => Items.Sum(x => x.Quantity * x.Price);
    public List<BasketItem> Items { get; set; } = new List<BasketItem>();
}
