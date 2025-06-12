using AutoMapper;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Repository.Repositories.Interface;
using Service.Dtos.Slider;
using Service.Helpers;
using Service.Helpers.Exceptions;
using Service.Services.Generic;
using Service.Services.Interface;

namespace Service.Services;

public class SliderService : CrudService<Slider, SliderCreateDto, SliderEditDto, SliderDto>, ISliderService
{

    private readonly ISliderRepository _repository;
    private readonly ICloudinaryManager _cloudinaryManager;
    public SliderService(ISliderRepository repository, IMapper mapper, ICloudinaryManager cloudinaryManager) : base(repository, mapper)
    {
        _repository = repository;
        _cloudinaryManager = cloudinaryManager;
    }


    public async Task<bool> CreateAsync(SliderCreateDto dto)
    {
        if (dto == null) return false;

        if (dto.Image == null || dto.Image.Length == 0)
            throw new NotFoundException("Image is requared");
        var result = FileHelper.ValidateImage(dto.Image);

        if (!result.IsSuccess)
        {
            throw new NotFoundException($" File Is not image or file size  200 mb");
        }
        var image =await  _cloudinaryManager.FileCreateAsync(dto.Image);

        var model = new Slider
        {
 
            CreatedDate = DateTime.UtcNow,
            EditDate = DateTime.UtcNow,
            BoldWrite = dto.BoldWrite,
            LightWrite= dto.LightWrite,
            Image = image,
            ButtonWrite = dto.ButtonWrite,


        };

         await _repository.CreateAsync(model);

        

        return true;

    }
}
