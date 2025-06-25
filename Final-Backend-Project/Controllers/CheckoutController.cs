using Microsoft.AspNetCore.Mvc;
using Service.Services;
using Service.Services.Interface;
using Service.ViewModels.Order;
using Service.ViewModels.Payment;

namespace Final_Backend_Project.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IPaymentService _paymentService;

        public CheckoutController(IOrderService orderService, IPaymentService paymentService)
        {
            _orderService = orderService;
            _paymentService = paymentService;
        }

        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Checkout(OrderCreateVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

        await   _orderService.CreateOrderAsync(vm);

          
            return RedirectToAction("Redirect");
        }

        public IActionResult Redirect()
        {
            string? url = Request.Cookies["paymentUrl"];
            if (!string.IsNullOrWhiteSpace(url))
            {
                Response.Cookies.Delete("paymentUrl");

                return Redirect(url);
            }

            //TempData["SuccedAlert"] = _localizer.GetValue("SuccedPayment");

            return RedirectToAction("List", "Order");
        }



        public async Task<IActionResult> CheckPayment(PaymentCheckVM dto)
        {
            var result = await _paymentService.CheckPaymentAsync(dto);

            if (result)
            {

                if (User.Identity?.IsAuthenticated ?? false)
                    return RedirectToAction("List", "Order");
            }


            return RedirectToAction("Index", "Shop");
        }

    }
}
