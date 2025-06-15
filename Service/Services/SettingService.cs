using AutoMapper;
using Domain.Entity;
using Repository.Repositories.Interface;
using Service.Dtos.Setting;
using Service.Helpers.Exceptions;
using Service.Helpers;
using Service.Services.Generic;
using Service.Services.Interface;

namespace Service.Services;

public class SettingService : CrudService<Setting, SettingCreateDto, SettingEditDto, SettingDto>, ISettingService
{
    private readonly ISettingRepository _settingRepository;
    private readonly ICloudinaryManager _cloudinaryManager;
    public SettingService(ISettingRepository repository, IMapper mapper, ICloudinaryManager cloudinaryManager) : base(repository, mapper)
    {
        _settingRepository = repository;
        _cloudinaryManager = cloudinaryManager;
    }

    public string GetSetting(string key)
    {
        return _settingRepository.GetSettingByKey(key);
    }

    public async Task<SettingEditDto> SettingUpdateDto(int id)
    {

        var setting = await _settingRepository.GetAsync(x => x.Id == id);


        var model = new SettingEditDto
        {
            Key = setting.Key,
            Value = setting.Value
        };

        return model;
    }

    public async Task UpdateSettingAsync(SettingEditDto settingUpdateDTO)
    {
        var setting = await _settingRepository.GetAsync(s => s.Id == settingUpdateDTO.Id);

        if (setting == null)
        {
            throw new NotFoundException("Setting not found");
        }

        if (settingUpdateDTO.UploadedImage != null)
        {
            var validationResult = FileHelper.ValidateImage(settingUpdateDTO.UploadedImage);
            if (!validationResult.IsSuccess)
                throw new NotFoundException("File is not image və size is not 200MB.");


            var filePath = await _cloudinaryManager.FileCreateAsync(settingUpdateDTO.UploadedImage);

            setting.Value = filePath;
        }
        else
        {
            if (settingUpdateDTO.Value == null)
            {
                throw new NotFoundException("Setting not found");
            }
            setting.Value = settingUpdateDTO.Value;

        }
        _settingRepository.Update(setting);

        await _settingRepository.SaveChangesAsync();
    }
}
