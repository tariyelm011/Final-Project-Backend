using Microsoft.AspNetCore.Http;
using Service.Dtos.Common;

namespace Service.Dtos.Slider;

public class SliderCreateDto : IDto
{
    public string BoldWrite { get; set; } = null!;
    public string LightWrite { get; set; } = null!;
    public string ButtonWrite { get; set; } = null!;
    public IFormFile Image { get; set; } = null!;
}
