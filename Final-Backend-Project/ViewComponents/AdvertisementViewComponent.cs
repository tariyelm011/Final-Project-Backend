using Microsoft.AspNetCore.Mvc;
using Service.Services.Interface;

namespace Final_Backend_Project.ViewComponents;

public class AdvertisementViewComponent : ViewComponent
{

    private readonly IAdvertisementService _advertisementService;

    public AdvertisementViewComponent(IAdvertisementService advertisementService)
    {
        _advertisementService = advertisementService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var vm = await _advertisementService.GetAsync(x => true);
        return View(vm);
    }

}