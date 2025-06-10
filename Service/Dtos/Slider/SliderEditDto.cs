using Microsoft.AspNetCore.Http;

namespace Service.Dtos.Slider;

public class SliderEditDto
{
    public string BoldWrite { get; set; } = null!;
    public string LightWrite { get; set; } = null!;
    public string ButtonWrite { get; set; } = null!;
    public IFormFile Image { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
}
