using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Dtos.Slider;
using Service.Services;
using Service.Services.Interface;

namespace Final_Backend_Project.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin,SuperAdmin")]

public class SliderController : Controller
{
    private readonly ISliderService _sliderService;

    public SliderController(ISliderService sliderService)
    {
        _sliderService = sliderService;
    }

    public async  Task<IActionResult> Index()
    {
        var sliders =await _sliderService.GetAllAsync();
        return View(sliders);
    } 
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(SliderCreateVM dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }
        await _sliderService.CreateAsync(dto);
        return RedirectToAction("Index");
    }
    public async Task<IActionResult> Edit(int id)
    {
        var model = await _sliderService.UpdateSliderVM(id);
        return View(model);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(SliderEditVM dto)
    {
        if (!ModelState.IsValid)
        {
            var model = await _sliderService.UpdateSliderVM(dto.Id);
            return View(model);
        }
        await _sliderService.UpdateAsync(dto);

        return RedirectToAction("Index");
    }
    public async Task<IActionResult> Detail(int id)
    {
        var slider = await _sliderService.GetAsync(x => x.Id == id);
        return View(slider);
    }

    public async Task<IActionResult> Delete(int id)
    {
      await  _sliderService.DeleteAsync(id);
        return RedirectToAction("index");
    }
}
