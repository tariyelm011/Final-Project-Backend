using AutoMapper;
using Domain.Entity;
using Repository.Repositories.Interface;
using Service.Dtos.Category;
using Service.Helpers;
using Service.Helpers.Exceptions;
using Service.Services.Generic;
using Service.Services.Interface;

namespace Service.Services;

public class CategoryService : CrudService<Category, CategoryCreateVM, CategoryEditVM, CategoryVM>, ICategoryService
{
    private readonly ICategoryRepository _repository;
    private readonly IMapper _mapper;
    private readonly ICloudinaryManager _cloudinaryManager;

    public CategoryService(ICategoryRepository repository, IMapper mapper, ICloudinaryManager cloudinaryManager) : base(repository, mapper)
    {
        _repository = repository;
        _mapper = mapper;
        _cloudinaryManager = cloudinaryManager;
    }
    public async Task<bool> CreateAsync(CategoryCreateVM dto)
    {
        if (dto == null) return false;

        if (string.IsNullOrWhiteSpace(dto.Name))
            throw new NotFoundException("Category is null");

        if (dto.ImageUrl == null || dto.ImageUrl.Length == 0)
            throw new NotFoundException("Image is requared");
        var result = FileHelper.ValidateImage(dto.ImageUrl);

        if (!result.IsSuccess)
        {
            throw new NotFoundException($" File Is not image or file size  200 mb");

        }
        var img = await _cloudinaryManager.FileCreateAsync(dto.ImageUrl);
        if (img == null)
            throw new Exception("image is not upload");


        var model = new Category
        {
            Name = dto.Name,
            ImageUrl = img,
            CreatedDate =DateTime.UtcNow,
            EditDate =DateTime.UtcNow

        };

        await _repository.CreateAsync(model);
        return true;
    }

    public async Task<bool> UpdateAsync(CategoryEditVM dto)
    {
        if (dto == null) return false;

        var category = await _repository.GetAsync(dto.Id);
        if (category == null)
            throw new NotFoundException("Not Found Category Name");

        if (string.IsNullOrWhiteSpace(dto.Name))
            throw new NotFoundException("Name is null");

        if (dto.ImageUrl != null && dto.ImageUrl.Length > 0)
        {
            var img = await _cloudinaryManager.FileCreateAsync(dto.ImageUrl);
            if (img == null)
                throw new NotFoundException("Not Found Image");
            var result = FileHelper.ValidateImage(dto.ImageUrl);

            if (!result.IsSuccess)
            {
                throw new NotFoundException($" File Is not image or file size  200 mb");

            }
            category.ImageUrl = img;
        }

        category.Name = dto.Name;
        _repository.Update(category);
        await _repository.SaveChangesAsync();
        return true;
    }
    public async Task<CategoryEditVM> CategoryUpdateVM(int id)
    {
        var category = await _repository.GetAsync(id);
        if (category is null)
        {
            throw new NotFoundException("category is null ");
        }

        var model = new CategoryEditVM
        {
            Name = category.Name,
            Image = category.ImageUrl
        };

        return model;
    }

}