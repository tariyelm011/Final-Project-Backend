using Domain.Entity;
using Microsoft.AspNetCore.Http;
using Service.Dtos.Common;

namespace Service.Dtos.Blog;

public class BlogEditVM 
{
    public int Id { get; set; }

    public string? Title { get; set; }
    public string? Content { get; set; } 
    public string Description { get; set; }
    public string? ImageUrl { get; set; }
    public IFormFile? Image { get; set; } 
    public DateTime? CreatedDate { get; set; }
    public DateTime? EditDate { get; set; }
}