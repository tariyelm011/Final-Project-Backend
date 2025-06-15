using Domain.Entity;
using Service.Dtos.Subscribe;
using Service.Services.Interface.Generic;

namespace Service.Services.Interface;

public interface ISubscribeService : ICrudService<Subscribe, SubscribeCreateDto, SubscribeEditDto, SubscribeDto>
{
    Task SubscribeCreate(SubscribeCreateDto dto);
}
