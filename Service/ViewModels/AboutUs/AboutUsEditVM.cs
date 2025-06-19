using Microsoft.AspNetCore.Http;
using Service.Dtos.Common;

namespace Service.Dtos.AboutUs;

public class AboutUsEditVM
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string BoldWrite { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Button { get; set; } = null!;
    public string Image { get; set; } = null!;
    public IFormFile? ImageUrl { get; set; }
}

