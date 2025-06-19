using Service.Dtos.Common;

namespace Service.Dtos.Setting;

public class SettingVM 
{
    public int Id { get; set; }
    public string Key { get; set; } = null!;
    public string Value { get; set; } = null!;
}

