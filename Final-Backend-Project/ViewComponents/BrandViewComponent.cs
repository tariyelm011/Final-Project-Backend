using Microsoft.AspNetCore.Mvc;
using Service.Services.Interface;

namespace Final_Backend_Project.ViewComponents;

public class BrandViewComponent : ViewComponent
{
    private readonly IBrandService _brandService;
public BrandViewComponent(IBrandService brandService)
    {
        _brandService = brandService;
    }

    public async Task <IViewComponentResult> InvokeAsync()
    {

        var brands = await _brandService.GetAllAsync();
        return View(brands);
    }
}
