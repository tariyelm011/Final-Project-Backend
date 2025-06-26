using Final_Backend_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Dtos.Product;
using Service.Services.Interface;
using System.Diagnostics;

namespace Final_Backend_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task< IActionResult> FilterProducts(int categoryId = 0)
        {
            List<ProductVM> products;

            if (categoryId == 0)
                products = await _productService.GetAllAsync();
            else
                products = await _productService.GetAllAsync(x=>x.CategoryId == categoryId);

            return PartialView("_ProductsPartial", products);
        }
    }
}
