namespace Service.Dtos.Subscribe;

public class SubscribeVM 
{
    public int Id { get; set; }
    public string Email { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
}
