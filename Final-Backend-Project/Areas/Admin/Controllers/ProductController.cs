using Microsoft.AspNetCore.Mvc;
using Service.Dtos.Product;
using Service.Services;
using Service.Services.Interface;

namespace Final_Backend_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task< IActionResult> Index()
        {
            var products = await _productService.GetAllAsync();
            return View(products);
        }

        public async Task< IActionResult> Create()
        {
            var dto = await _productService.CreateProductVM();
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateVM dto)
        {
            var dtos = await _productService.CreateProductVM();
            dto.Categories = dtos.Categories;
            dto.Brands = dtos.Brands;

            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            var result = await _productService.CreateAsync(dto);

            if (!result.Success)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }
                var categories = await _productService.CreateProductVM();
                dto.Categories = categories.Categories;
                dto.Brands = categories.Brands;
                return View(dto);
            }

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(int id)
        {
            var delete = await _productService.DeleteAsync(id);
            return RedirectToAction("index");

        }

        public async Task<IActionResult>  Edit(int id)
        {
         var edit = await _productService.ProductUpdateVM(id);

            return View(edit);
        }

        [HttpPost]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductEditVM dto)
        {
            var dtos = await _productService.ProductUpdateVM(dto.Id);
            dto.Categories = dtos.Categories;
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var result = await _productService.UpdateAsync(dto);
            if (!result.Success)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }
                return View(dto);
            }

            return RedirectToAction("Index");
        }
    }
}
