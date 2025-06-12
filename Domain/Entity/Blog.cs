using Domain.Common;

namespace Domain.Entity;

public class Blog : BaseEntity
{
    public string AppUserId { get; set; } = null!;
    public AppUser AppUser { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public DateTime? CreatedDate { get; set; }
    public DateTime? EditDate { get; set; }
}