using Domain.Entity;
using Service.Dtos.Setting;
using Service.Services.Interface.Generic;

namespace Service.Services.Interface;

public interface ISettingService : ICrudService<Setting, SettingCreateVM, SettingEditVM, SettingVM>
{
    string GetSetting(string key);
    Task<SettingEditVM> SettingUpdateVM(int id);
    Task UpdateAsync(SettingEditVM settingUpdateDTO);
}
