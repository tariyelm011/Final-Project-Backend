using Microsoft.AspNetCore.Http;
using Service.Dtos.Common;

namespace Service.Dtos.Setting;

public class SettingEditVM 
{
    public int Id { get; set; }
    public string? Key { get; set; }
    public string? Value { get; set; }
    public IFormFile? UploadedImage { get; set; }
}

