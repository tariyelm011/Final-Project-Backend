using Service.Dtos.Category;
using Service.Dtos.ProductImage;

namespace Service.Dtos.Product;

public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string VideoUrl { get; set; } = null!;
    public List<ProductImageDto>? ProductImages { get; set; } = [];
    public List<CategoryDto> Categories { get; set; } = [];


}
