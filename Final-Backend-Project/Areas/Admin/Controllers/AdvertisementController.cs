using Microsoft.AspNetCore.Mvc;
using Service.Dtos.Advertisement;
using Service.Services.Interface;

namespace Final_Backend_Project.Areas.Admin.Controllers;
[Area("Admin")]


public class AdvertisementController : Controller
{
    private readonly IAdvertisementService _advertisementService;

    public AdvertisementController(IAdvertisementService advertisementService)
    {
        _advertisementService = advertisementService;
    }

    public async Task< IActionResult> Index()
    {
        var advertisements = await _advertisementService.GetAllAsync();
        return View(advertisements);
    }


    public async Task<IActionResult> Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(AdvertisementCreateVM vm)
    {
        if (!ModelState.IsValid)
        {
            return View(vm);
        }
        await _advertisementService.CreateAsync(vm);
        return RedirectToAction("Index");

    }

    public async Task<IActionResult> Edit(int id)
    {
      var advertisement = await _advertisementService.AdvertisementsVM(id);
        return View(advertisement);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(AdvertisementEditVM vm)
    {
        if (!ModelState.IsValid)
        {
            return View(vm);
        }
        await _advertisementService.UpdateAsync(vm);
        await _advertisementService.SaveChangesAsync();
        return RedirectToAction("Index");

    }



    public async Task<IActionResult> Delete(int id)
    {
        await _advertisementService.DeleteAsync(id);
        return RedirectToAction("Index");
    }



}
