using Microsoft.AspNetCore.Mvc;
using Service.Services.Interface;

namespace Final_Backend_Project.ViewComponents;

public class ProductPapularViewComponent : ViewComponent
{
    private readonly IProductService _productService;

    public ProductPapularViewComponent(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {

        var products = await _productService.GetProductsBySellCountAsync();
        return View(products);
    }
}