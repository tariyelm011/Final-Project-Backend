namespace Service.ViewModels.FeaturedProduct;

public class FeaturedProductVM
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public string ProductName { get; set; }

    public decimal OriginalPrice { get; set; }

    public decimal DiscountedPrice { get; set; }

    public DateTime CountdownEndDate { get; set; }

    public string ProductImageUrl { get; set; }
}
