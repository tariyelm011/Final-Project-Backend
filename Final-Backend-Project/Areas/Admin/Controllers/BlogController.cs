using Microsoft.AspNetCore.Mvc;
using Service.Dtos.Blog;
using Service.Services;
using Service.Services.Interface;

namespace Final_Backend_Project.Areas.Admin.Controllers;

    [Area("Admin")]
public class BlogController : Controller
{
    private readonly IBlogService _blogService;

    public BlogController(IBlogService blogService)
    {
        _blogService = blogService;
    }

    public async Task< IActionResult> Index()
    {
        var blogs = await _blogService.GetAllAsync();
        return View(blogs);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(BlogCreateDto dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }
        var result = await _blogService.CreateBlog(dto);
        if (!result.Success)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }

            return View(dto);
        }
        return RedirectToAction("index");
    }

    public async Task<IActionResult> Delete(int id)
    {
        var delete = await _blogService.DeleteAsync(id);
        return RedirectToAction("index");

    }

    public async Task<IActionResult> Edit(int id)
    {
        var model = await _blogService.BlogUpdateDto(id);
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(BlogEditDto dto)
    {
      
        var result = await _blogService.Update(dto);
       
        return RedirectToAction("index");
    }

}
