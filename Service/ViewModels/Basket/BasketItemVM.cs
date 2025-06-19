namespace Service.ViewModels.Basket;

public class BasketItemVM
{
    public string? img { get; set; }
    public int ProductId { get; set; }
    public int Count { get; set; }
    public string ProductName { get; set; } = null!;
    public decimal ProductPrice { get; set; }
    public decimal TotalProductPrice { get; set; }
}
