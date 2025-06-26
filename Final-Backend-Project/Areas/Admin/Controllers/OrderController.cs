using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.Services;
using Service.Services.Interface;

namespace Final_Backend_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task< IActionResult> Index()
        {

            var orders = await _orderService.GetAllAsync(include: x => x.Include(c => c.Payment));

            return View(orders);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var delete = await _orderService.DeleteAsync(id);
            return RedirectToAction("index");

        }
    }
}
