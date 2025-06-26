using Microsoft.AspNetCore.Mvc;
using Service.Dtos.Brand;
using Service.Dtos.Category;
using Service.Services;
using Service.Services.Interface;

namespace Final_Backend_Project.Areas.Admin.Controllers;

[Area("Admin")]

public class BrandController : Controller
{
    private readonly IBrandService _brandService;

    public BrandController(IBrandService brandService)
    {
        _brandService = brandService;
    }

    public async Task< IActionResult> Index()
    {
        var brands = await _brandService.GetAllAsync();
        return View(brands);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(BrandCreateVM dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }
        await _brandService.CreateAsync(dto);
        return RedirectToAction("index");
    }
    public async Task<IActionResult> Detail(int id)
    {
        var brand = await _brandService.GetAsync(x => x.Id == id);
        return View(brand);
    }
    public async Task<IActionResult> Edit(int id)
    {
        var edit = await _brandService.BrandUpdateVM(id);
        return View(edit);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(BrandEditVM dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }
        await _brandService.UpdateAsync(dto);
        return RedirectToAction("index");
    }

    public async Task<IActionResult> Delete(int id)
    {
        var delete = await _brandService.DeleteAsync(id);
        return RedirectToAction("index");

    }
}
