using Domain.Common;

namespace Domain.Entity;

public class AboutUs : BaseEntity
{
    public string Title { get; set; } = null!;
    public string BoldWrite { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Button { get; set; } = null!;
    public string Image { get; set; } = null!;

}