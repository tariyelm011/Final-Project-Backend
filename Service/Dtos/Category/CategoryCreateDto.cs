using Microsoft.AspNetCore.Http;
using Service.Dtos.Common;

namespace Service.Dtos.Category;

public class CategoryCreateDto : IDto
{
    public string Name { get; set; } = null!;
    public IFormFile ImageUrl { get; set; } = null!;
    public int ProductId { get; set; }
}
