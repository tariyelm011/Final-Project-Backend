using Final_Backend_Project.ViewModelsUI;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Interface;

namespace Final_Backend_Project.Controllers
{
    public class AboutUsController : Controller
    {
        private readonly IAboutUsService _aboutUsService;
        private readonly IExpertService _expertService;

        public AboutUsController(IAboutUsService aboutUsService, IExpertService expertService)
        {
            _aboutUsService = aboutUsService;
            _expertService = expertService;
        }

        public async Task< IActionResult> Index()
        {
            var aboutUsVM = await _aboutUsService.GetAsync(x => true);

            var experts = await _expertService.GetAllAsync();
            var model = new AboutUsUiVM { AboutUsVM = aboutUsVM,Experts=experts };

            return View(model);
        }
    }
}
