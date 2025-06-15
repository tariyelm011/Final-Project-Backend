using Microsoft.AspNetCore.Mvc;
using Service.Dtos.Subscribe;
using Service.Services.Interface;

namespace Final_Backend_Project.Controllers
{
    public class SubscribeController : Controller
    {
        private readonly ISubscribeService _subscribeService;

        public SubscribeController(ISubscribeService subscribeService)
        {
            _subscribeService = subscribeService;
        }

        [HttpPost]
        public async Task<IActionResult> Subscribe(SubscribeCreateDto dto)
        {
            if (!ModelState.IsValid) return RedirectToAction("Index", "Home");

            await _subscribeService.SubscribeCreate(dto);
            return RedirectToAction("Index", "Home");
        }
    }
}
