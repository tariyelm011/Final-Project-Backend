namespace Service.ViewModels.OrderItem;

public class OrderItemVM
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public int Count { get; set; }

    public decimal TotalPrice { get; set; }
}
