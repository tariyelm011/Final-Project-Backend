using Service.Dtos.Common;

namespace Service.Dtos.Subscribe;

public class SubscribeDto : IDto
{
    public int Id { get; set; }
    public string Email { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
}
