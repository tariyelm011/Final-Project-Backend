using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Service.Dtos.Brand;
using Service.Dtos.Category;
using Service.Dtos.Common;
using Service.Dtos.ProductImage;

namespace Service.Dtos.Product;

public class ProductEditDto : IDto
{
    public int Id { get; set; }
    public string? Name { get; set; } 
    public string? Description { get; set; } 
    public IFormFile? ImageUrl { get; set; } 
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string? ImageMain { get; set; }
    public int CategoryId { get; set; }
    public int? BrandId { get; set; }
    public List<ProductImageDto>? ProductImagesUrl { get; set; } = [];
    public List<SelectListItem>? Categories { get; set; } = [];
    public List<SelectListItem>? Brands { get; set; } = [];
    public List<CategoryDto>? CategoriesGet { get; set; } = [];
    public List<BrandDto>? BrandsGet { get; set; } = [];
    public List<IFormFile>? ProductImages { get; set; } = [];
    public IFormFile? VideoUrl { get; set; }
    public string? Video { get; set; }
}