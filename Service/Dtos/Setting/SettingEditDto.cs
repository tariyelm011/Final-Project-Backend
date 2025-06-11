using Service.Dtos.Common;

namespace Service.Dtos.Setting;

public class SettingEditDto : IDto
{
    public string Key { get; set; } = null!;
    public string Value { get; set; } = null!;
}

