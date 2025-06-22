using Domain.Entity;
using Service.Dtos.Brand;
using Service.Services.Interface.Generic;

namespace Service.Services.Interface;

public interface IBrandService : ICrudService<Brand, BrandCreateVM, BrandEditVM, BrandVM>
{
    Task<bool> CreateAsync(BrandCreateVM dto);
    Task<bool> UpdateAsync(BrandEditVM dto);
    Task<BrandEditVM> BrandUpdateVM(int id);
}

