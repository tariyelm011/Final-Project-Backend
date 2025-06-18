using Microsoft.AspNetCore.Http;
using Service.Dtos.Common;

namespace Service.Dtos.AboutUs;

public class AboutUsCreateVM : IDto
{
    public string Title { get; set; } = null!;
    public string BoldWrite { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Button { get; set; } = null!;
    public IFormFile Image { get; set; } = null!;
}

