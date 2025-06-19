using Domain.Entity;
using Service.Dtos.Slider;
using Service.Services.Interface.Generic;

namespace Service.Services.Interface;

public interface ISliderService : ICrudService<Slider, SliderCreateVM, SliderEditVM, SliderVM>
{
    Task<bool> CreateAsync(SliderCreateVM dto);
    Task<bool> UpdateAsync(SliderEditVM updateSliderDto); 
    Task<SliderEditVM> UpdateSliderVM(int id);
    Task DeleteAsync(int id);
}
