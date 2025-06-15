using AutoMapper;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository.Repositories.Interface;
using Service.Dtos.Product;
using Service.Dtos.ProductImage;
using Service.Helpers.Exceptions;
using Service.Helpers;
using Service.Services.Generic;
using Service.Services.Interface;

namespace Service.Services;

public class ProductService : CrudService<Product, ProductCreateDto, ProductEditDto, ProductDto>, IProductService
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;
    private readonly ICloudinaryManager _cloudinaryManager;
    private readonly ICategoryService _categoryService;
    private readonly IProductImageRepository _productImageRepository;
    private readonly IBrandService _brandService;

    public ProductService(IProductRepository repository, IMapper mapper, ICloudinaryManager cloudinaryManager, ICategoryService categoryService, IProductImageRepository productImageRepository, IBrandService brandService) : base(repository, mapper)
    {
        _repository = repository;
        _mapper = mapper;
        _cloudinaryManager = cloudinaryManager;
        _categoryService = categoryService;
        _productImageRepository = productImageRepository;
        _brandService = brandService;
    }
    public async Task<(bool Success, List<string> Errors)> UpdateProductAsync(ProductEditDto dto)
    {
        var errors = new List<string>();

        if (dto == null)
        {
            errors.Add("Product data is null.");
            return (false, errors);
        }

        var product = await _repository.GetAsync(dto.Id);
        if (product == null)
        {
            errors.Add("Product not found.");
            return (false, errors);
        }

        bool isUpdated = false;

        if (string.IsNullOrEmpty(dto.Name))
            errors.Add("Product name is required.");
        else if (dto.Name != product.Name)
        {
            product.Name = dto.Name;
            isUpdated = true;
        }

        if (string.IsNullOrEmpty(dto.Description))
            errors.Add("Product description is required.");
        else if (dto.Description != product.Description)
        {
            product.Description = dto.Description;
            isUpdated = true;
        }

        if (dto.Price < 0)
            errors.Add("Price must be a positive value.");
        else if (dto.Price != product.Price)
        {
            product.Price = dto.Price;
            isUpdated = true;
        }

        if (dto.CategoryId <= 0)
            errors.Add("Invalid category.");
        else if (dto.CategoryId != product.CategoryId)
        {
            product.CategoryId = dto.CategoryId;
            isUpdated = true;
        }

        if (dto.BrandId <= 0)
            errors.Add("Invalid brand.");
        else if (dto.BrandId != product.BrandId)
        {
            product.BrandId = dto.BrandId;
            isUpdated = true;
        }


        if (dto.Stock <= 0)
            errors.Add("Invalid Stock.");
        else if (dto.Stock != product.Stock)
        {
            product.Stock = dto.Stock;
            isUpdated = true;
        }

        product.EditDate = DateTime.UtcNow;
        if (dto.ImageUrl != null && dto.ImageMain != product.ImageUrl)
        {
            var newMainImage = await _cloudinaryManager.FileCreateAsync(dto.ImageUrl);
            product.ImageUrl = newMainImage;
            isUpdated = true;
        }

        _repository.Update(product);

        await _repository.SaveChangesAsync();

        if (dto.ProductImages != null && dto.ProductImages.Any())
        {
            foreach (var image in dto.ProductImages)
            {
                var uploadedImageUrl = await _cloudinaryManager.FileCreateAsync(image);
                var imageRecord = new ProductImage { ProductId = product.Id, ImageUrl = uploadedImageUrl };
                await _productImageRepository.CreateAsync(imageRecord);
            }
        }


        return (true, new List<string>());
    }


    public async Task<ProductEditDto> GetProductUpdateDto(int productId)
    {
        var product = await _repository.GetAsync(productId);
        if (product == null) return null;

        var categories = await _categoryService.GetAllAsync();
        var brands = await _brandService.GetAllAsync();
        var images = _productImageRepository.GetAll().Where(x => x.ProductId == productId).ToList();

        var productUpdateDto = new ProductEditDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Stock = product.Stock,
            Description = product.Description,
            ImageMain = product.ImageUrl,
            Video = product.VideoUrl,
            
            Categories = categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name,
                Selected = c.Id == product.CategoryId
            }).ToList(),
            CategoryId = product.CategoryId,

            Brands = brands.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name,
                Selected = c.Id == product.CategoryId
            }).ToList(),
            BrandId = product.BrandId,


        };

        return productUpdateDto;
    }


    public async Task<(bool Success, List<string> Errors)> ProductCreate(ProductCreateDto dto)
    {
        var errors = new List<string>();

        if (dto == null)
        {
            errors.Add("Product data is null.");
            return (false, errors);
        }

        if (dto.ProductImages.Count == 0)
        {
            errors.Add("Product images are required.");
            return (false, errors);
        }

        if (string.IsNullOrEmpty(dto.Name))
        {
            errors.Add("Product name is required.");
        }


        if (string.IsNullOrEmpty(dto.Description))
        {
            errors.Add("Product description is required.");
        }

        if (dto.Price < 0)
        {
            errors.Add($"Price: {dto.Price} is not valid");
        }



        if (dto.Stock < 0)
        {
            errors.Add($"Stock: {dto.Price} is not valid");
        }
        if (dto.CategoryId <= 0)
        {
            errors.Add("Category must be a valid ID.");
        }
        var category = await _categoryService.GetAsync(dto.CategoryId);
        if (category == null)
        {
            errors.Add("Category must be a valid ID.");
        }

        if (dto.ImageUrl == null)
        {
            errors.Add("main image is required");
        }



        if (dto.VideoUrl == null)
        {
            errors.Add("Video is required");
        }


        if (errors.Any()) return (false, errors);

        if (dto.ImageUrl == null || dto.ImageUrl.Length == 0)
            throw new NotFoundException("Image is requared");
        var result = FileHelper.ValidateImage(dto.ImageUrl);

        if (!result.IsSuccess)
        {
            throw new NotFoundException($" File Is not image or file size  200 mb");
        }
        if (dto.VideoUrl == null || dto.VideoUrl.Length == 0)
            throw new NotFoundException("video is requared");

        var resultvideo = FileHelper.ValidateVideo(dto.VideoUrl);

        if (!resultvideo.IsSuccess)
        {
            throw new NotFoundException($" File Is not image or file size  200 mb");
        }
        var imageMain = await _cloudinaryManager.FileCreateAsync(dto.ImageUrl);
        var videoUrl = await _cloudinaryManager.VideoUploadAsync(dto.VideoUrl);
        var model = new Product
        {
            Name = dto.Name,
            Price = dto.Price,
            Description = dto.Description,
            ImageUrl = imageMain,
             CategoryId = dto.CategoryId,
             BrandId = dto.BrandId,
             VideoUrl = videoUrl,
             Stock = dto.Stock,
            CreatedDate = DateTime.UtcNow,
            EditDate = DateTime.UtcNow

        };

        if (dto.ProductImages is null)
        {
            errors.Add(" Images are required");
        }
        await _repository.CreateAsync(model);

        foreach (var image in dto.ProductImages)
        {
            var uploadedImageUrl = await _cloudinaryManager.FileCreateAsync(image);
            var imageRecord = new ProductImage { ProductId = model.Id, ImageUrl = uploadedImageUrl ,CreatedDate = DateTime.UtcNow, EditDate =DateTime.UtcNow};
            await _productImageRepository.CreateAsync(imageRecord);
        }

     
        return (true, new List<string>());



    }


    public async Task<ProductCreateDto> GetCreatedProductDto()
    {
        var categories = await _categoryService.GetAllAsync();
        var brands = await _brandService.GetAllAsync();

        var model = new ProductCreateDto
        {
            Categories = categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList(),

            Brands = brands.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList()
        };

        return model;
    }

}
