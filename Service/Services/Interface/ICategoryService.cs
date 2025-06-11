using Domain.Entity;
using Service.Dtos.Category;
using Service.Services.Interface.Generic;

namespace Service.Services.Interface;

public interface ICategoryService : ICrudService<Category, CategoryCreateDto, CategoryEditDto, CategoryDto>
{
    Task<bool> CreateAsync(CategoryCreateDto dto);
    Task<bool> UpdateAsync(CategoryEditDto dto);
    Task<CategoryEditDto> GetCategoryUpdate(int id);
}
