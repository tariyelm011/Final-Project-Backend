using Service.Dtos.Common;

namespace Service.Dtos.Expert;

public class ExpertVM 
{
    public int Id { get; set; } 
    public string Name { get; set; } = null!;
    public string Job { get; set; } = null!;
    public string Image { get; set; } = null!;
}


