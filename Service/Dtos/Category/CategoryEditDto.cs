using Microsoft.AspNetCore.Http;
using Service.Dtos.Common;

namespace Service.Dtos.Category;

public class CategoryEditDto : IDto
{
    public string? Name { get; set; } 
    public IFormFile? ImageUrl { get; set; }
    public int ProductId { get; set; }
}