using Microsoft.AspNetCore.Http;
using Service.Dtos.Common;

namespace Service.Dtos.Brand;

public class BrandCreateDto : IDto
{
    public string Name { get; set; } = null!;
    public IFormFile ImageUrl { get; set; } = null!;
    public DateTime? CreatedDate { get; set; }
    public DateTime? EditDate { get; set; }
}
