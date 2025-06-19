using AutoMapper;
using Domain.Entity;
using Repository.Repositories.Interface;
using Service.Dtos.AboutUs;
using Service.Dtos.Expert;
using Service.Services.Generic;
using Service.Services.Interface;

namespace Service.Services;

public class AboutUsService : CrudService<AboutUs, AboutUsCreateVM, AboutUsEditVM, AboutUsVM>, IAboutUsService
{
    private readonly IAboutUsRepository _aboutUsRepository;
    private readonly IMapper _mapper;
    private readonly ICloudinaryManager _cloudinaryManager;
    public AboutUsService(IAboutUsRepository repository, IMapper mapper, ICloudinaryManager cloudinaryManager) : base(repository, mapper)
    {
        _aboutUsRepository = repository;
        _mapper = mapper;
        _cloudinaryManager = cloudinaryManager;
    }
    public async Task<AboutUsEditVM> AboutUsVm(int id)
    {
        var about = await _aboutUsRepository.GetAsync(id);
        var vm = _mapper.Map<AboutUsEditVM>(about);

        return vm;
    }

    public async Task CreateAsync(AboutUsCreateVM vm)
    {


        var image = await _cloudinaryManager.FileCreateAsync(vm.Image);

        var about = new AboutUs
        {
            Title = vm.Title,
            BoldWrite = vm.BoldWrite,
            Description = vm.Description,
            Button = vm.Button,
            Image = image

        };

        await _aboutUsRepository.CreateAsync(about);

    }

    public async Task UpdateAsync(AboutUsEditVM vm)
    {
        var about = await _aboutUsRepository.GetAsync(vm.Id);
        if (about == null) throw new Exception("Expert is not found!");

        if (vm.ImageUrl != null)
        {
            var newImage = await _cloudinaryManager.FileCreateAsync(vm.ImageUrl);
            about.Image = newImage;
        }

        about.Title = vm.Title;
        about.Description = vm.Description;
        about.BoldWrite = vm.BoldWrite;
        about.Button = vm.Button;

        _aboutUsRepository.Update(about);
        await _aboutUsRepository.SaveChangesAsync();
    }
}
