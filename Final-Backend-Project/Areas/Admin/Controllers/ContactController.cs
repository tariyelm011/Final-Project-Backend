using Microsoft.AspNetCore.Mvc;
using Service.Services.Interface;
using Service.ViewModels.Contact;

namespace Final_Backend_Project.Areas.Admin.Controllers;

[Area("Admin")]
public class ContactController : Controller
{
    private readonly IContactService _contactService;

    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }

    public async Task<IActionResult> Index()
    {
        var contactVMs = await _contactService.GetAllAsync();
        return View(contactVMs);
    }

    public async Task<IActionResult> Detail(int id)
    {
        var contactVM = await _contactService.GetAsync(id);

        return View(contactVM);
    }

    public async Task<IActionResult> Answer(int id)
    {
        var contactvm = await _contactService.ContactCreateVMAsync(id);

        return View(contactvm);
    }
    [HttpPost]
    public async Task<IActionResult> Answer(ContactCreateVM vm)
    {
       var model = await _contactService.SendEmailContact(vm);
        return RedirectToAction("index");
    }

    public async Task<IActionResult> Delete(int id)
    {
        await _contactService.DeleteAsync(id);
        return RedirectToAction("index");
    }


}
