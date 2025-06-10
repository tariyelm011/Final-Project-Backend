using Microsoft.AspNetCore.Http;

namespace Service.Dtos.Category;

public class CategoryEditDto
{
    public string? Name { get; set; } 
    public IFormFile? ImageUrl { get; set; }
    public int ProductId { get; set; }
}