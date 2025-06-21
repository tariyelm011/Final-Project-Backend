using Microsoft.AspNetCore.Mvc;
using Service.Services.Interface;

namespace Final_Backend_Project.ViewComponents;

public class CategoryViewComponent : ViewComponent
{
    private readonly ICategoryService _categoryService;

    public CategoryViewComponent(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var category = await _categoryService.CategoriesWithProductCountAsync();
        return View(category);
    }

}