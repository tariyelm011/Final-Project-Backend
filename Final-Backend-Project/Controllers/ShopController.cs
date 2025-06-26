using Final_Backend_Project.ViewModelsUI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.Services.Interface;

namespace Final_Backend_Project.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ShopController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index(string? search, string? sort, List<int>? categoryIds, decimal? priceFrom, decimal? priceTo, int page = 1)
        {
            int take = 2;

            var categories = await _categoryService.GetAllAsync();

            var paginatedProducts = await _productService.GetFilteredPaginatedProductsAsync(
                search, sort, categoryIds, priceFrom, priceTo, page, take);

            var vm = new ShopVM
            {
                Products = paginatedProducts,
                Categories = categories,
                Search = search,
                Sort = sort,
                CategoryIds = categoryIds,
                PriceFrom = priceFrom,
                PriceTo = priceTo,

            };

            return View(vm);
        }


        public async Task<IActionResult> Detail(int id)
        {
            var vm = await _productService.GetAsync(x => x.Id == id, include: x => x.Include(f => f.ProductImages).Include(f => f.Category).Include(f => f.Brand));

            return View(vm);
        }

    }
}
