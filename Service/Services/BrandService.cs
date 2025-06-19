using AutoMapper;
using Domain.Entity;
using Repository.Repositories.Interface;
using Service.Dtos.Brand;
using Service.Helpers;
using Service.Helpers.Exceptions;
using Service.Services.Generic;
using Service.Services.Interface;

namespace Service.Services;

public class BrandService : CrudService<Brand, BrandCreateVM, BrandEditVM, BrandVM>, IBrandService
{
    private readonly ICloudinaryManager _cloudinaryManager;
    private readonly IBrandRepository _brandRepository;
    public BrandService(IBrandRepository repository, IMapper mapper, ICloudinaryManager cloudinaryManager) : base(repository, mapper)
    {
        _cloudinaryManager = cloudinaryManager;
        _brandRepository = repository;
    }

    public async Task<BrandEditVM> BrandUpdateVM(int id)
    {
        var brand = await _brandRepository.GetAsync(id);
        if (brand is null)
        {
            throw new NotFoundException("Brand is null ");
        }

        var model = new BrandEditVM
        {
            Name = brand.Name,
            Image = brand.ImageUrl
        };

        return model;
    }

   public async Task<bool> CreateAsync(BrandCreateVM dto)
    {
        if (dto == null) return false;

        if (string.IsNullOrWhiteSpace(dto.Name))
            throw new NotFoundException("Brand is null");

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


        var model = new Brand
        {
            Name = dto.Name,
            ImageUrl = img,
            CreatedDate = DateTime.UtcNow,
            EditDate = DateTime.UtcNow

        };

        await _brandRepository.CreateAsync(model);
        return true;
    }

  public async  Task<bool> UpdateAsync(BrandEditVM dto)
    {
        if (dto == null) return false;

        var brand = await _brandRepository.GetAsync(dto.Id);
        if (brand == null)
            throw new NotFoundException("Not Found brand Name");

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
            brand.ImageUrl = img;
        }

        brand.Name = dto.Name;
        _brandRepository.Update(brand);
        await _brandRepository.SaveChangesAsync();
        return true;
    }
}
