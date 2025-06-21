using Domain.Entity;
using Service.Dtos.Category;
using Service.Services.Interface.Generic;

namespace Service.Services.Interface;

public interface ICategoryService : ICrudService<Category, CategoryCreateVM, CategoryEditVM, CategoryVM>
{
    Task<bool> CreateAsync(CategoryCreateVM dto);
    Task<bool> UpdateAsync(CategoryEditVM dto);
    Task<CategoryEditVM> CategoryUpdateVM(int id);
    Task<List<CategoryWithProductCountVM>> CategoriesWithProductCountAsync();
}
