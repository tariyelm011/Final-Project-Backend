using Service.Dtos.Common;

namespace Service.Dtos.Slider;

public class SliderDto : IDto
{
    public string BoldWrite { get; set; } = null!;
    public string LightWrite { get; set; } = null!;
    public string ButtonWrite { get; set; } = null!;
    public string Image { get; set; } = null!;
}
