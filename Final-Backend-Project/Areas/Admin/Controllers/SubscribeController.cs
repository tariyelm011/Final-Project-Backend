using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Interface;

namespace Final_Backend_Project.Areas.Admin.Controllers;

[Area("Admin")]
public class SubscribeController : Controller
{
    private readonly ISubscribeService _subscribeService;

    public SubscribeController(ISubscribeService subscribeService)
    {
        _subscribeService = subscribeService;
    }

    public async Task<IActionResult> Index()
    {
        var subscribe = await _subscribeService.GetAllAsync();
        return View(subscribe);
    }

    public async Task<IActionResult> Delete(int id)
    {
       await _subscribeService.DeleteAsync(id);
        return RedirectToAction("Index");
    }
}
