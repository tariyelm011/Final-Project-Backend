using Microsoft.AspNetCore.Mvc;
using Service.Dtos.Slider;
using Service.Services.Interface;

namespace Final_Backend_Project.Areas.Admin.Controllers;

[Area("Admin")]
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
    public async Task<IActionResult> Create(SliderCreateDto dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }
        await _sliderService.CreateAsync(dto);
        return RedirectToAction("Index");
    }
}
