using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories.Interface;
using Service.Services;
using Service.Services.Interface;
using Service.ViewModels.FeaturedProduct;

namespace Final_Backend_Project.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin,SuperAdmin")]

public class FeaturedProductController : Controller
{
    private readonly IFeaturedProductService _featuredProductService;
    private readonly IProductRepository _productRepository;
    private readonly IProductService _productService;

    public FeaturedProductController(IFeaturedProductService featuredProductService, IProductRepository productRepository, IProductService productService)
    {
        _featuredProductService = featuredProductService;
        _productRepository = productRepository;
        _productService = productService;
    }

    public async Task<IActionResult> Index()
    {
        var featuredProducts = await _featuredProductService.FeaturedProductsAsync();
        return View(featuredProducts);
    }
    public async Task<IActionResult> Create()
    {
        var products = await _productService.GetAllAsync(x => x.Stock > 0);

        var viewModel = new FeaturedProductCreateVM
        {
            Products = products.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name
            }).ToList()
        };

        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Create(FeaturedProductCreateVM vm)
    {
        if (!ModelState.IsValid)
        {
            var products = await _productService.GetAllAsync(x => x.Stock > 0);
            var viewModel = new FeaturedProductCreateVM
            {
                Products = products.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name
                }).ToList()
            };
            return View(viewModel);
        }

        await _featuredProductService.CreateAsync(vm);


        return RedirectToAction("index");
    }

    public async Task<IActionResult> Edit(int id)
    {
        var vm = await _featuredProductService.GetByIdForEditAsync(id);
        return View(vm);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(FeaturedProductEditVM vm)
    {
        await _featuredProductService.EditAsync(vm);
        return RedirectToAction("index");

    }

    public async Task<IActionResult> Delete(int id)
    {
    await _featuredProductService.Delete(id);
        return RedirectToAction("index");

    }

    [HttpPost]
    public async Task<IActionResult> RestoreOriginalPriceAndRemoveFromFeatured(int productId)
    {
        await _featuredProductService.RestoreOrginalPrice(productId);
        return Ok(new { success = true });
    }

}
