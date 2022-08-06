namespace BasketService.Domain.Entities;

public class Basket
{
    public string BasketId { get; set; }
    public List<BasketItem> Items { get; set; } = new List<BasketItem>();

    public Basket()
    {
    }

    public Basket(string basketId)
    {
        BasketId = basketId;
    }

    public decimal TotalPrice => Items.Sum(x => x.Quantity * x.Price);
}
