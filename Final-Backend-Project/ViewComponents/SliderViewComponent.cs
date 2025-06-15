using Microsoft.AspNetCore.Mvc;
using Service.Services.Interface;

namespace Final_Backend_Project.ViewComponents;

public class SliderViewComponent : ViewComponent
{
    private readonly ISliderService _sliderService;

    public SliderViewComponent(ISliderService sliderService)
    {
        _sliderService = sliderService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var sliders = await _sliderService.GetAllAsync();
        return View(sliders);
    }

}
