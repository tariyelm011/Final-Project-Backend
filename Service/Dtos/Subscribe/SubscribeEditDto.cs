using Service.Dtos.Common;

namespace Service.Dtos.Subscribe;

public class SubscribeEditDto : IDto
{
    public string Email { get; set; } = null!;
    public DateTime SubscribedDate { get; set; }
}
