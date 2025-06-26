using Final_Backend_Project.ViewModelsUI;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Interface;

namespace Final_Backend_Project.ViewComponents;

public class CategoryProductViewComponent : ViewComponent
{

    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;

    public CategoryProductViewComponent(IProductService productService, ICategoryService categoryService)
    {
        _productService = productService;
        _categoryService = categoryService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var products = await _productService.GetAllAsync();
        var categorys = await _categoryService.GetAllAsync();


        var vm = new CategoryProductVM
        {
            Products = products,
            Categories = categorys
        };
        return View(vm);
    }
}
