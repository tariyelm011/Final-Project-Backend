using Service.Dtos.Common;

namespace Service.Dtos.ProductImage;

public class ProductImageDto : IDto
{
    public string ImageUrl { get; set; } = null!;
    public int ProductId { get; set; }

}
