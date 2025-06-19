using Domain.Entity;
using Service.Dtos.Blog;
using Service.Helpers.Exceptions;
using Service.Services.Interface.Generic;

namespace Service.Services.Interface;

public interface IBlogService : ICrudService<Blog, BlogCreateVM, BlogEditVM, BlogVM>
{

    Task<(bool Success, List<string> Errors)> CreateAsync(BlogCreateVM dto);
    Task<bool> UpdateAsync(BlogEditVM dto);
    Task<BlogEditVM> BlogUpdateVM(int id);
    Task<PaginationResponse<BlogVM>> GetPaginateAsync(int page, int take);
}
