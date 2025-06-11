using AutoMapper;
using Domain.Entity;
using Repository.Repositories.Interface;
using Service.Dtos.Subscribe;
using Service.Services.Generic;
using Service.Services.Interface;

namespace Service.Services;

public class SubscribeService : CrudService<Subscribe, SubscribeCreateDto, SubscribeEditDto, SubscribeDto>, ISubscribeService
{
    public SubscribeService(ISubscribeRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
