using AutoMapper;
using Domain.Entity;
using Repository.Repositories.Interface;
using Service.Dtos.Advertisement;
using Service.Services.Generic;
using Service.Services.Interface;

namespace Service.Services;

public class AdvertisementService : CrudService<Advertisement, AdvertisementCreateVM, AdvertisementEditVM, AdvertisementVM>, IAdvertisementService
{
    private readonly IAdvertisementRepository _advertisementRepository;
    private readonly IMapper _mapper;

    public AdvertisementService(IAdvertisementRepository repository, IMapper mapper) : base(repository, mapper)
    {
        _advertisementRepository = repository;
        _mapper = mapper;
    }

    public async Task<AdvertisementEditVM> AdvertisementsAsync(int id)
    {
        var advertisements = await _advertisementRepository.GetAsync(id);
        var vm = _mapper.Map<AdvertisementEditVM>(advertisements);

        return vm;
    }
}