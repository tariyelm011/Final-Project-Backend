namespace Service.ViewModels.Wishlist;

public class WishlistVM
{
    public string? img { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; } = null!;
    public decimal ProductPrice { get; set; }
    public decimal TotalProductPrice { get; set; }
}