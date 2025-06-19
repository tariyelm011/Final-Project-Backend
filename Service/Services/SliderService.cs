using AutoMapper;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories.Interface;
using Service.Dtos.Slider;
using Service.Helpers;
using Service.Helpers.Exceptions;
using Service.Services.Generic;
using Service.Services.Interface;

namespace Service.Services;

public class SliderService : CrudService<Slider, SliderCreateVM, SliderEditVM, SliderVM>, ISliderService
{

    private readonly ISliderRepository _repository;
    private readonly ICloudinaryManager _cloudinaryManager;
    public SliderService(ISliderRepository repository, IMapper mapper, ICloudinaryManager cloudinaryManager) : base(repository, mapper)
    {
        _repository = repository;
        _cloudinaryManager = cloudinaryManager;
    }


    public async Task<bool> CreateAsync(SliderCreateVM dto)
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

    public async Task<SliderEditVM> UpdateSliderVM(int id)
    {
        var dto = await _repository.GetAsync(id);
        if (dto == null) throw new NotFoundException();

        var update = new SliderEditVM
        {
            Id = id,
            BoldWrite = dto.BoldWrite,
            ButtonWrite = dto.ButtonWrite,
            LightWrite = dto.LightWrite,
           ImageUrl = dto.Image,

        };

        return update;


    }
    public async Task<bool> UpdateAsync(SliderEditVM updateSliderDto)
    {
        if (updateSliderDto is null)
        {
            throw new NotFoundException();
        }

        var slider = await _repository.GetAsync(updateSliderDto.Id);

        if (slider == null) throw new NotFoundException();
        if (updateSliderDto.Image != null)
        {

            var validationResult = FileHelper.ValidateImage(updateSliderDto.Image);
            if (!validationResult.IsSuccess)
                throw new NotFoundException("File is not image və size is not 200MB.");
            string newImageUrl = await _cloudinaryManager.FileCreateAsync(updateSliderDto.Image);

            slider.Image = newImageUrl;
        }

    
        slider.BoldWrite = updateSliderDto.BoldWrite;
        slider.LightWrite = updateSliderDto.LightWrite;
        slider.ButtonWrite = updateSliderDto.ButtonWrite;
        slider.EditDate = DateTime.UtcNow;

        _repository.Update(slider);
        await _repository.SaveChangesAsync();

        return true;
    }


    public async Task DeleteAsync(int id)
    {
        var allSliders = await _repository.GetAll().ToListAsync(); 

        if (allSliders.Count <= 1)
        {
            throw new InvalidOperationException("At least one slider must remain"); 
        }

        var slider = await _repository.GetAsync(id); 

        if (slider == null)
        {
            throw new KeyNotFoundException($"Slider with id {id} not found.");
        }

        await _repository.Delete(slider); 
    }


}
