using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Service.Dtos.Category;
using Service.Dtos.Common;
using Service.Dtos.ProductImage;

namespace Service.Dtos.Product;

public class ProductCreateDto : IDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public IFormFile ImageUrl { get; set; } = null!;
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public int CategoryId { get; set; }
    public int BrandId { get; set; }

    public IFormFile VideoUrl { get; set; } = null!;
    public List<IFormFile> ProductImages { get; set; } = new List<IFormFile>();
    public List<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
    public List<SelectListItem> Brands { get; set; } = new List<SelectListItem>();


}
