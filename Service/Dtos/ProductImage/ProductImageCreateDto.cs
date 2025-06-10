using Microsoft.AspNetCore.Http;

namespace Service.Dtos.ProductImage;

public class ProductImageCreateDto
{
    public IFormFile ImageUrl { get; set; } = null!;
    public int ProductId { get; set; }
}
