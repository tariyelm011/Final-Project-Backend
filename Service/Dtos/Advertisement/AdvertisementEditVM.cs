using Service.Dtos.Common;

namespace Service.Dtos.Advertisement;

public class AdvertisementEditVM : IDto
{
    public int Id { get; set; } 
    public string Title { get; set; } = null!;
    public string YoutubeLink { get; set; } = null!;
}
