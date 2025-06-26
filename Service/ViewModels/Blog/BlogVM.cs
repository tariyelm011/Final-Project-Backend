using Domain.Entity;
using Service.Dtos.Common;

namespace Service.Dtos.Blog;

public class BlogVM
{
    public int Id { get; set; }
    public string AppUserId { get; set; } = null!;
    public AppUser AppUser { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Content { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public DateTime? CreatedDate { get; set; }
    public DateTime? EditDate { get; set; }
}
