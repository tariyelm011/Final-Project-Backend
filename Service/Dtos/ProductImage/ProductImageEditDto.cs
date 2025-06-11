using Microsoft.AspNetCore.Http;
using Service.Dtos.Common;

namespace Service.Dtos.ProductImage;

public class ProductImageEditDto : IDto
{
    public IFormFile? ImageUrl { get; set; }
    public int ProductId { get; set; }
}