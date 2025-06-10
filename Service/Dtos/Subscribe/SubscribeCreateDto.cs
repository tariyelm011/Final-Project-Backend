namespace Service.Dtos.Subscribe;

public class SubscribeCreateDto
{
    public string Email { get; set; } = null!;
    public DateTime SubscribedDate { get; set; }
}
