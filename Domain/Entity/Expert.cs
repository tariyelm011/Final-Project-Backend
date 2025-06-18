using Domain.Common;

namespace Domain.Entity;

public class Expert : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Job { get; set; } = null!;
    public string Image { get; set; } = null!;

}
