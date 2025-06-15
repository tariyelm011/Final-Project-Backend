using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.Services.Interface;

namespace Final_Backend_Project.ViewComponents;

public class BlogViewComponent : ViewComponent
{
    private readonly IBlogService _blogService;

    public BlogViewComponent(IBlogService blogService)
    {
        _blogService = blogService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var blogs = await _blogService.GetAllAsync(
            orderBy: q => q.OrderByDescending(b => b.CreatedDate),
            take: 3 ,include : x=>x.Include(a=>a.AppUser));

        return View(blogs);
    }

}

