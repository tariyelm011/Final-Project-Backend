﻿using Service.Dtos.Common;

namespace Service.Dtos.Advertisement;

public class AdvertisementVM 
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string YoutubeLink { get; set; } = null!;
}
