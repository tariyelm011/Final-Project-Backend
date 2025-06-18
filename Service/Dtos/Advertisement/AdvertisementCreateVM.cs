using Service.Dtos.Common;

namespace Service.Dtos.Advertisement;

public class AdvertisementCreateVM : IDto
{
    public string Title { get; set; } = null!;
    public string YoutubeLink { get; set; } = null!;
}
