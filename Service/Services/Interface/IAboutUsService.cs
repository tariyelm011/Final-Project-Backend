using Domain.Entity;
using Service.Dtos.AboutUs;
using Service.Services.Interface.Generic;

namespace Service.Services.Interface;

public interface IAboutUsService : ICrudService<AboutUs, AboutUsCreateVM, AboutUsEditVM, AboutUsVM>
{
    Task UpdateAboutUs(AboutUsEditVM vm);
    Task CreateAboutUs(AboutUsCreateVM vm);
    Task<AboutUsEditVM> AboutUsAsync(int id);
}