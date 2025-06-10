using Microsoft.AspNetCore.Http;
using Service.Dtos.Category;
using Service.Dtos.ProductImage;

namespace Service.Dtos.Product;

public class ProductCreateDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public IFormFile ImageUrl { get; set; } = null!;
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public IFormFile VideoUrl { get; set; } = null!;
    public List<ProductImageCreateDto>? ProductImages { get; set; } = [];
    public List<CategoryCreateDto> Categories { get; set; } = [];

}
