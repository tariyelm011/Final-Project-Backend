using Domain.Entity;
using Service.Dtos.Setting;
using Service.Services.Interface.Generic;

namespace Service.Services.Interface;

public interface ISettingService : ICrudService<Setting, SettingCreateDto, SettingEditDto, SettingDto>
{
    
}
