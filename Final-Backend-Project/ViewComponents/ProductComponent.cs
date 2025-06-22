using Microsoft.AspNetCore.Mvc;
using Service.Services.Interface;

namespace Final_Backend_Project.ViewComponents;

public class ProductViewComponent : ViewComponent
{
    private readonly IProductService _productService;

    public ProductViewComponent(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {

        var products = await _productService.GetLatestProductsAsync();
        return View(products);
    }
}
