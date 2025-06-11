using AutoMapper;
using Domain.Entity;
using Repository.Repositories.Interface;
using Service.Dtos.Category;
using Service.Services.Generic;
using Service.Services.Interface;

namespace Service.Services;

public class CategoryService : CrudService<Category, CategoryCreateDto, CategoryEditDto, CategoryDto>, ICategoryService
{
    public CategoryService(ICategoryRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}