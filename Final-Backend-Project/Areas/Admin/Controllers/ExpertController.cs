using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Dtos.Expert;
using Service.Services;
using Service.Services.Interface;

namespace Final_Backend_Project.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize(Roles = "Admin,SuperAdmin")]


public class ExpertController : Controller
{
    private readonly IExpertService _expertService;

    public ExpertController(IExpertService expertService)
    {
        _expertService = expertService;
    }

    public async Task<IActionResult> Index()
    {
        var experts =await _expertService.GetAllAsync();
        return View(experts);
    }

    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task< IActionResult> Create(ExpertCreateVM vm)
    {
        if (!ModelState.IsValid)
        {
            return View(vm);
        }
        await _expertService.CreateAsync(vm);
        return RedirectToAction("index");

    }


    public async Task <IActionResult> Edit(int id)
    {
        var vm = await _expertService.ExpertUpdateAsyncVM(id);
        return View(vm);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ExpertEditVM vm)
    {
      await _expertService.UpdateAsync(vm);
        return RedirectToAction("index");

    }
    public async Task<IActionResult> Detail(int id)
    {
        var expert = await _expertService.GetAsync(x => x.Id == id);
        return View(expert);
    }
    public async Task<IActionResult> Delete(int id)
    {
        var delete = await _expertService.DeleteAsync(id);
        return RedirectToAction("index");

    }
}
