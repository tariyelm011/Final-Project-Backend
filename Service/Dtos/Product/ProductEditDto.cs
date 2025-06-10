using Microsoft.AspNetCore.Http;
using Service.Dtos.Category;
using Service.Dtos.ProductImage;

namespace Service.Dtos.Product;

public class ProductEditDto
{
    public string? Name { get; set; } 
    public string? Description { get; set; } 
    public IFormFile? ImageUrl { get; set; } 
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public List<ProductImageDto>? ProductImagesUrl { get; set; } = [];
    public List<CategoryCreateDto> Categories { get; set; } = [];
    public List<CategoryDto> CategoriesGet { get; set; } = [];
    public List<ProductImageCreateDto>? ProductImages { get; set; } = [];
    public IFormFile? VideoUrl { get; set; }
}