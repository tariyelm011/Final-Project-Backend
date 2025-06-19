using Domain.Entity;
using Service.Dtos.AboutUs;
using Service.Services.Interface.Generic;

namespace Service.Services.Interface;

public interface IAboutUsService : ICrudService<AboutUs, AboutUsCreateVM, AboutUsEditVM, AboutUsVM>
{
    Task UpdateAsync(AboutUsEditVM vm);
    Task CreateAsync(AboutUsCreateVM vm);
    Task<AboutUsEditVM> AboutUsVm(int id);
}