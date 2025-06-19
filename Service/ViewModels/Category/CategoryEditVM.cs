using Microsoft.AspNetCore.Http;
using Service.Dtos.Common;

namespace Service.Dtos.Category;

public class CategoryEditVM 
{
    public int Id { get; set; }
    public string? Name { get; set; } 
    public IFormFile? ImageUrl { get; set; }
    public string? Image { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? EditDate { get; set; }
}