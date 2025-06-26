using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Dtos.Setting;
using Service.Services.Interface;

namespace Final_Backend_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperAdmin")]

    public class SettingController : Controller
    {
        private readonly ISettingService _settingService;

        public SettingController(ISettingService settingService)
        {
            _settingService = settingService;
        }

        public async Task<IActionResult> Index()
        {
            var settings = await _settingService.GetAllAsync();
            return View(settings);
        }

        public async Task<IActionResult> Create()
        {

            return View();
        }
        public async Task<IActionResult> Edit(int id)
        {
            var updateDto = await _settingService.SettingUpdateVM(id);

            return View(updateDto);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(SettingEditVM dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            await _settingService.UpdateAsync(dto);

            return RedirectToAction("index");
        }
    }
}
