using Microsoft.AspNetCore.Http;
using Service.Dtos.Common;

namespace Service.Dtos.Setting;

public class SettingEditDto : IDto
{
    public int Id { get; set; }
    public string? Key { get; set; }
    public string? Value { get; set; }
    public IFormFile? UploadedImage { get; set; }
}

