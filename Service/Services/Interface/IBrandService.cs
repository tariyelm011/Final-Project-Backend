using Domain.Entity;
using Service.Dtos.Brand;
using Service.Services.Interface.Generic;

namespace Service.Services.Interface;

public interface IBrandService : ICrudService<Brand, BrandCreateDto, BrandEditDto, BrandDto>
{
    Task<bool> CreateAsync(BrandCreateDto dto);
    Task<bool> UpdateAsync(BrandEditDto dto);
    Task<BrandEditDto> GetBrandUpdate(int id);
}