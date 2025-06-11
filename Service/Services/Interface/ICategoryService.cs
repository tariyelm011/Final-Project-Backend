using Domain.Entity;
using Service.Dtos.Category;
using Service.Services.Interface.Generic;

namespace Service.Services.Interface;

public interface ICategoryService : ICrudService<Category, CategoryCreateDto, CategoryEditDto, CategoryDto>
{
   
}
