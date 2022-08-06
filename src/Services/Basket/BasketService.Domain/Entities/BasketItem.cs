namespace BasketService.Domain.Entities; 

public class BasketItem
{
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string ProductId { get; set; }
    public string ProductName { get; set; }
    public string Image { get; set; }
    public string Link { get; set; }
}
