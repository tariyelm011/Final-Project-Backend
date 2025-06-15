using AutoMapper;
using Domain.Entity;
using Repository.Repositories.Interface;
using Service.Dtos.Subscribe;
using Service.Services.Generic;
using Service.Services.Interface;

namespace Service.Services;

public class SubscribeService : CrudService<Subscribe, SubscribeCreateDto, SubscribeEditDto, SubscribeDto>, ISubscribeService
{
    private readonly ISubscribeRepository _subscribeRepository;
    public SubscribeService(ISubscribeRepository repository, IMapper mapper) : base(repository, mapper)
    {
        _subscribeRepository = repository;
    }


    public async Task SubscribeCreate(SubscribeCreateDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Email))
            return;

        string normalizedEmail = dto.Email.Trim().ToLower();

        var allSubscribes =  _subscribeRepository.GetAll();
        bool emailExists = allSubscribes.Any(s => s.Email.Trim().ToLower() == normalizedEmail);
        if (emailExists)
            return;

        await _subscribeRepository.CreateAsync(new Subscribe
        {
            Email = normalizedEmail,
            CreatedDate = DateTime.UtcNow
        });
    }


}
