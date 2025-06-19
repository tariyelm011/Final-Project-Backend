using Service.Dtos.Common;

namespace Service.Dtos.Slider;

public class SliderVM 
{
    public int Id { get; set; }
    public string BoldWrite { get; set; } = null!;
    public string LightWrite { get; set; } = null!;
    public string ButtonWrite { get; set; } = null!;
    public string Image { get; set; } = null!;
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime? EditDate { get; set; } = null;
}
