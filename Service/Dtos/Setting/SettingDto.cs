using Service.Dtos.Common;

namespace Service.Dtos.Setting;

public class SettingDto : IDto
{
    public int Id { get; set; }
    public string Key { get; set; } = null!;
    public string Value { get; set; } = null!;
}

