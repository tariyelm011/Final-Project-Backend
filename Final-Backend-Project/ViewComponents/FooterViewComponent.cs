using Microsoft.AspNetCore.Mvc;

namespace Final_Backend_Project.ViewComponents;

public class FooterViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
