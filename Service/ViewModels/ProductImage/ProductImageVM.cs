using Service.Dtos.Common;

namespace Service.Dtos.ProductImage;

public class ProductImageVM 
{
    public string ImageUrl { get; set; } = null!;
    public int ProductId { get; set; }

}
