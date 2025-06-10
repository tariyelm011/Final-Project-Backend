using Microsoft.AspNetCore.Http;

namespace Service.Dtos.ProductImage;

public class ProductImageEdiDto
{
    public IFormFile? ImageUrl { get; set; }
    public int ProductId { get; set; }
}