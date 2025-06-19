using Service.Dtos.Common;

namespace Service.Dtos.Subscribe;

public class SubscribeCreateVM 
{
    public string Email { get; set; } = null!;
    public DateTime SubscribedDate { get; set; }
}
