using Domain.Common;

namespace Domain.Entity;

public class Slider : BaseEntity
{
    public string BoldWrite { get; set; }=null!;
    public string LightWrite { get; set; }=null!;
    public string ButtonWrite { get; set; } = null!;
    public DateTime? CreatedDate { get; set; }
    public DateTime? EditDate { get; set; }
    public string Image { get; set; } = null!;

}
