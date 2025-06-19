using Domain.Entity;
using Service.Dtos.Subscribe;
using Service.Services.Interface.Generic;

namespace Service.Services.Interface;

public interface ISubscribeService : ICrudService<Subscribe, SubscribeCreateVM, SubscribeEditVM, SubscribeVM>
{
    Task CreateAsync(SubscribeCreateVM dto);
}
