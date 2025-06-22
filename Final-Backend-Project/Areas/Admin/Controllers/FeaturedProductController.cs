using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories.Interface;
using Service.Services;
using Service.Services.Interface;
using Service.ViewModels.FeaturedProduct;

namespace Final_Backend_Project.Areas.Admin.Controllers;

    [Area("Admin")]
public class FeaturedProductController : Controller
{
    private readonly IFeaturedProductService _featuredProductService;
    private readonly IProductRepository _productRepository;

    public FeaturedProductController(IFeaturedProductService featuredProductService, IProductRepository productRepository)
    {
        _featuredProductService = featuredProductService;
        _productRepository = productRepository;
    }

    public async  Task<IActionResult> Index()
    {
        var featuredProducts =await _featuredProductService.FeaturedProductsAsync();
        return View(featuredProducts);
    }
    public async Task<IActionResult> Create()
    {
        var products =  _productRepository.GetAll(); 
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
            var products = _productRepository.GetAll();
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
        var delete = await _featuredProductService.DeleteAsync(id);
        return RedirectToAction("index");

    }

    [HttpPost]
    public async Task<IActionResult> RestoreOriginalPriceAndRemoveFromFeatured(int productId)
    {
       await _featuredProductService.RestoreOrginalPrice(productId);
        return Ok(new { success = true });
    }

}
