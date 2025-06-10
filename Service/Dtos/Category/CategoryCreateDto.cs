using Microsoft.AspNetCore.Http;

namespace Service.Dtos.Category;

public class CategoryCreateDto
{
    public string Name { get; set; } = null!;
    public IFormFile ImageUrl { get; set; } = null!;
    public int ProductId { get; set; }
}
