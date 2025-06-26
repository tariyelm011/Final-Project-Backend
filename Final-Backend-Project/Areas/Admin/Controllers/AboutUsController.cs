using Microsoft.AspNetCore.Mvc;
using Service.Dtos.AboutUs;
using Service.Dtos.Expert;
using Service.Services;
using Service.Services.Interface;

namespace Final_Backend_Project.Areas.Admin.Controllers;

[Area("Admin")]

public class AboutUsController : Controller
{
    private readonly IAboutUsService _aboutUsService;

    public AboutUsController(IAboutUsService aboutUsService)
    {
        _aboutUsService = aboutUsService;
    }



    public async Task<IActionResult> Index()
    {
        var about = await _aboutUsService.GetAllAsync();
        return View(about);
    }

    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(AboutUsCreateVM vm)
    {
        if (!ModelState.IsValid)
        {
            return View(vm);
        }
        await _aboutUsService.CreateAsync(vm);
        return RedirectToAction("index");

    }

    public async Task<IActionResult> Detail(int id)
    {
        var about = await _aboutUsService.GetAsync(x=>x.Id == id);
        return View(about);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var vm = await _aboutUsService.AboutUsVm(id);
        return View(vm);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(AboutUsEditVM vm)
    {
        await _aboutUsService.UpdateAsync(vm);
        return RedirectToAction("index");

    }

    public async Task<IActionResult> Delete(int id)
    {
       await _aboutUsService.DeleteAsync(id);
        return RedirectToAction("index");

    }
}
