using AutoMapper;
using Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories.Interface;
using Service.Dtos.Blog;
using Service.Dtos.Product;
using Service.Helpers;
using Service.Helpers.Exceptions;
using Service.Services.Generic;
using Service.Services.Interface;
using System.Security.Claims;

namespace Service.Services;

public class BlogService : CrudService<Blog, BlogCreateVM, BlogEditVM, BlogVM>, IBlogService
{
    private readonly IBlogRepository _repository;
    private readonly ICloudinaryManager _cloudinaryManager;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public BlogService(IBlogRepository repository, IMapper mapper, ICloudinaryManager cloudinaryManager, IHttpContextAccessor httpContextAccessor) : base(repository, mapper)
    {
        _repository = repository;
        _cloudinaryManager = cloudinaryManager;
        _httpContextAccessor = httpContextAccessor;
        _mapper = mapper;
    }
    public async Task<(bool Success, List<string> Errors)> CreateAsync(BlogCreateVM dto)
    {
        var errors = new List<string>();


       
        var result = FileHelper.ValidateImage(dto.ImageUrl);

        if (!result.IsSuccess)
        {
            errors.Add($" File Is not image or file size  200 mb");
            return (false, errors);
        }


        if (dto.Title is null)
        {
            errors.Add($" Text Is requared");
            return (false, errors);
        }
        if (dto.Content is null)
        {
            errors.Add($" Description Is requared");
            return (false, errors);
        }

        var imagePath = await _cloudinaryManager.FileCreateAsync(dto.ImageUrl);
        string userId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;


        var model = new Blog
        {

             Title= dto.Title,
            Content = dto.Content,
            Description = dto.Description,
            ImageUrl = imagePath,
            CreatedDate = DateTime.UtcNow,
            EditDate = DateTime.UtcNow,
            AppUserId = userId,
        };

        await _repository.CreateAsync(model);

        return (true, new List<string>());

    }

    public async Task<BlogEditVM> BlogUpdateVM(int id)
    {
        var blog = await _repository.GetAsync(id);

        if (blog == null)
        {
            throw new NotFoundException("Not Found");
        }

        var blopUpdateDto = new BlogEditVM { Id = blog.Id, Title = blog.Title, Content = blog.Content, ImageUrl = blog.ImageUrl,Description = blog.Description };

        return blopUpdateDto;

    }
    public async Task<bool> UpdateAsync(BlogEditVM dto)
    {
        if (dto == null)
            throw new NotFoundException("Blog not found");

        var existingBlog = await _repository.GetAsync(dto.Id,asNotTracking: false);
        if (existingBlog == null)
            throw new NotFoundException("Blog not found.");

        bool isSameData =
            existingBlog.Title == dto.Title &&
            existingBlog.Content == dto.Content && existingBlog.Description == dto.Description &&
            dto.Image == null;

        if (isSameData)
            return true;

        string? imagePath = existingBlog.ImageUrl;
        if (dto.Image != null)
        {
            var validationResult = FileHelper.ValidateImage(dto.Image);
            if (!validationResult.IsSuccess)
                throw new NotFoundException("File is not image və size is not 200MB.");

            imagePath = await _cloudinaryManager.FileCreateAsync(dto.Image);

        }

        existingBlog.Title = dto.Title;
        existingBlog.Content = dto.Content;
        existingBlog.Description = dto.Description;
        existingBlog.ImageUrl = imagePath;
        existingBlog.EditDate = DateTime.UtcNow;

        _repository.Update(existingBlog);
        await _repository.SaveChangesAsync();

        return true;
    }


    public async Task<PaginationResponse<BlogVM>> GetPaginateAsync(int page, int take)
    {
        var products = _repository.GetAll( include: x=>x.Include(a=>a.AppUser));

        int count = products.Count();
        int totalPage = (int)Math.Ceiling((decimal)count / take);

        var data = _mapper.Map<List<BlogVM>>(products
            .Skip((page - 1) * take)
            .Take(take)
            .ToList());


        return new PaginationResponse<BlogVM>(data, totalPage, page, count);
    }


}
