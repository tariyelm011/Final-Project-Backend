using Domain.Entity;
using Microsoft.AspNetCore.Http;
using Service.Dtos.Common;

namespace Service.Dtos.Blog;

public class BlogCreateDto : IDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public IFormFile ImageUrl { get; set; } = null!;
    public DateTime? CreatedDate { get; set; }
    public DateTime? EditDate { get; set; }
}
