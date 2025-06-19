using Service.Dtos.Common;

namespace Service.Dtos.Setting;

public class SettingCreateVM
{
    public string Key { get; set; } = null!;
    public string Value { get; set; } = null!;
}

