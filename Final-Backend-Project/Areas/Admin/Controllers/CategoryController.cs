using Microsoft.AspNetCore.Mvc;
using Service.Dtos.Category;
using Service.Services.Interface;

namespace Final_Backend_Project.Areas.Admin.Controllers
{
        [Area("Admin")]

    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var catagories = await _categoryService.GetAllAsync();
            return View(catagories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateVM dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            await _categoryService.CreateAsync(dto);
            return RedirectToAction("index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var edit = await _categoryService.CategoryUpdateVM(id);
            return View(edit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryEditVM dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            await _categoryService.UpdateAsync(dto);
            return RedirectToAction("index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var delete = await _categoryService.DeleteAsync(id);
            return RedirectToAction("index");

        }
    }
}
