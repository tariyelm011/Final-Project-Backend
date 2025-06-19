using Microsoft.AspNetCore.Http;
using Service.Dtos.Common;

namespace Service.Dtos.ProductImage;

public class ProductImageCreateVM 
{
    public IFormFile ImageUrl { get; set; } = null!;
    public int ProductId { get; set; }
}
