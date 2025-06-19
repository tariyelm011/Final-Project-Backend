using Microsoft.AspNetCore.Http;
using Service.Dtos.Common;

namespace Service.Dtos.Brand;

public class BrandEditVM
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public IFormFile? ImageUrl { get; set; }
    public string? Image { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? EditDate { get; set; }
}
