using Final_Backend_Project.ViewModelsUI;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Interface;

namespace Final_Backend_Project.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProductService productService;

        public ShopController(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<IActionResult> Index(string? search, string? sort, int? categoryId, int page = 1)
        {
            int take = 2;

            var paginatedProducts = await productService.GetFilteredPaginatedProductsAsync(
                search,
                sort,
                categoryId,
                page,
                take);

            ViewBag.Search = search;

            var vm = new ShopVM
            {
                Products = paginatedProducts,
                Sort = sort,
                CategoryId = categoryId
            };

            return View(vm);
        }


    }
}
