using Microsoft.AspNetCore.Mvc;
using Service.Services.Interface;
using Service.ViewModels.Contact;

namespace Final_Backend_Project.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ContactCreateVM vm)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("index", "Contact");

            }
            await _contactService.CreateAsync(vm);
            return RedirectToAction("index", "Home");

            
        }
    }
}
