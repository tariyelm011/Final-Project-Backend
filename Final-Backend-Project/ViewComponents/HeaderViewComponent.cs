using Microsoft.AspNetCore.Mvc;

namespace Final_Backend_Project.ViewComponents;

public class HeaderViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}

