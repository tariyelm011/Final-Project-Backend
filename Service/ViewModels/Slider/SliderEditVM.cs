using Microsoft.AspNetCore.Http;
using Service.Dtos.Common;

namespace Service.Dtos.Slider;

public class SliderEditVM 
{
    public int Id { get; set; }
    public string BoldWrite { get; set; } = null!;
    public string LightWrite { get; set; } = null!;
    public string ButtonWrite { get; set; } = null!;
    public IFormFile? Image { get; set; }
    public string? ImageUrl { get; set; }
}
