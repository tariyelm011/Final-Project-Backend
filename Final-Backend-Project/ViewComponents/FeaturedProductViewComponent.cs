using Microsoft.AspNetCore.Mvc;
using Service.Services.Interface;

namespace Final_Backend_Project.ViewComponents;

public class FeaturedProductViewComponent : ViewComponent
{
    private readonly IFeaturedProductService _featuredProductService;

    public FeaturedProductViewComponent(IFeaturedProductService featuredProductService)
    {
        _featuredProductService = featuredProductService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var featuredProducts =await _featuredProductService.FeaturedProductsAsync();
        return View(featuredProducts);
    }
}
