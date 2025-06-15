using Domain.Entity;
using Service.Dtos.Setting;
using Service.Services.Interface.Generic;

namespace Service.Services.Interface;

public interface ISettingService : ICrudService<Setting, SettingCreateDto, SettingEditDto, SettingDto>
{
    string GetSetting(string key);
    Task<SettingEditDto> SettingUpdateDto(int id);
    Task UpdateSettingAsync(SettingEditDto settingUpdateDTO);
}
