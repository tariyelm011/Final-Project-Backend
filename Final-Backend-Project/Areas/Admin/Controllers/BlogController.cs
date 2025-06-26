using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public async Task<IActionResult> Create(BlogCreateVM dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }
        var result = await _blogService.CreateAsync(dto);
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
        var model = await _blogService.BlogUpdateVM(id);
        return View(model);
    }
    public async Task<IActionResult> Detail(int id)
    {
        var blog = await _blogService.GetAsync(x => x.Id == id ,include: x=>x.Include(a=>a.AppUser));
        return View(blog);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(BlogEditVM dto)
    {
      
        var result = await _blogService.UpdateAsync(dto);
       
        return RedirectToAction("index");
    }

}
