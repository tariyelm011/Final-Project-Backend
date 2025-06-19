using AutoMapper;
using Domain.Entity;
using Repository.Repositories.Interface;
using Service.Dtos.Expert;
using Service.Services.Generic;
using Service.Services.Interface;

namespace Service.Services;

public class ExpertService : CrudService<Expert, ExpertCreateVM, ExpertEditVM, ExpertVM>, IExpertService
{
    private readonly IExpertRepository _expertRepository;
    private readonly IMapper _mapper;
    private readonly ICloudinaryManager _cloudinaryManager;
    public ExpertService(IExpertRepository repository, IMapper mapper, ICloudinaryManager cloudinaryManager) : base(repository, mapper)
    {
        _expertRepository = repository;
        _mapper = mapper;
        _cloudinaryManager = cloudinaryManager;
    }


    public async Task<ExpertEditVM> ExpertUpdateAsyncVM(int id)
    {
        var experts = await _expertRepository.GetAsync(id);
        var vm = _mapper.Map<ExpertEditVM>(experts);

        return vm;
    }

    public async Task CreateAsync(ExpertCreateVM vm)
    {

        
        var image = await _cloudinaryManager.FileCreateAsync(vm.Image);

        var expert = new Expert
        {
            Name = vm.Name,
            Job = vm.Job,
            Image = image

        };

        await _expertRepository.CreateAsync(expert);

    }

    public async Task UpdateAsync(ExpertEditVM vm)
    {
        var expert = await _expertRepository.GetAsync(vm.Id);
        if (expert == null) throw new Exception("Expert is not found!");

        if (vm.ImageUrl != null)
        {
            var newImage = await _cloudinaryManager.FileCreateAsync(vm.ImageUrl);
            expert.Image = newImage;
        }

        expert.Name = vm.Name;
        expert.Job = vm.Job;

         _expertRepository.Update(expert);
        await _expertRepository.SaveChangesAsync();
    }

}
