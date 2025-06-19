using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.Services.Interface;

namespace Final_Backend_Project.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task <IActionResult> Index(int page = 1)
        {
            var vm = await _blogService.GetPaginateAsync(page , take:6);
            return View(vm);
        }


        public async Task<IActionResult> Detail(int id)
        {
            var blog = await _blogService.GetAsync(x => x.Id == id, include: x => x.Include(f => f.AppUser));
            if (blog == null) return NotFound();
            return View(blog);
        }
    }
}
