using AutoMapper;
using Domain.Entity;
using Repository.Repositories.Interface;
using Service.Dtos.Setting;
using Service.Services.Generic;
using Service.Services.Interface;

namespace Service.Services;

public class SettingService : CrudService<Setting, SettingCreateDto, SettingEditDto, SettingDto>, ISettingService
{
    public SettingService(ISettingRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
