using AutoMapper;
using Domain.Entity;
using Repository.Repositories.Interface;
using Service.Dtos.Slider;
using Service.Services.Generic;
using Service.Services.Interface;

namespace Service.Services;

public class SliderService : CrudService<Slider, SliderCreateDto, SliderEditDto, SliderDto>, ISliderService
{
    public SliderService(ISliderRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
