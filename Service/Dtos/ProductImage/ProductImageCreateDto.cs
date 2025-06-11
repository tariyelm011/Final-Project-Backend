using Microsoft.AspNetCore.Http;
using Service.Dtos.Common;

namespace Service.Dtos.ProductImage;

public class ProductImageCreateDto : IDto
{
    public IFormFile ImageUrl { get; set; } = null!;
    public int ProductId { get; set; }
}
