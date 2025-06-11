using Service.Dtos.Common;

namespace Service.Dtos.Subscribe;

public class SubscribeDto : IDto
{
    public string Email { get; set; } = null!;
    public DateTime SubscribedDate { get; set; }
}
