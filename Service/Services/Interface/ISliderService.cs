using Domain.Entity;
using Service.Dtos.Slider;
using Service.Services.Interface.Generic;

namespace Service.Services.Interface;

public interface ISliderService : ICrudService<Slider, SliderCreateDto, SliderEditDto, SliderDto>
{
    Task<bool> CreateAsync(SliderCreateDto dto);
    Task<bool> UpdateSlider(SliderEditDto updateSliderDto); 
    Task<SliderEditDto> GetUpdateSliderDto(int id);
    Task DeleteSlider(int id);
}
