using Domain.Entity;
using Service.Dtos.Slider;
using Service.Services.Interface.Generic;

namespace Service.Services.Interface;

public interface ISliderService : ICrudService<Slider, SliderCreateDto, SliderEditDto, SliderDto>
{
    Task<bool> CreateAsync(SliderCreateDto dto);    
}
