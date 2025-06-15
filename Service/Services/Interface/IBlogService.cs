using Domain.Entity;
using Service.Dtos.Blog;
using Service.Services.Interface.Generic;

namespace Service.Services.Interface;

public interface IBlogService : ICrudService<Blog, BlogCreateDto, BlogEditDto, BlogDto>
{

    Task<(bool Success, List<string> Errors)> CreateBlog(BlogCreateDto dto);
    Task<bool> Update(BlogEditDto dto);
    Task<BlogEditDto> BlogUpdateDto(int id);
}
