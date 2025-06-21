using Microsoft.AspNetCore.Mvc;
using Service.Services.Interface;

namespace Final_Backend_Project.Controllers;

public class WishlistController : Controller
{
    private readonly IWishlistService _wishlistService;

    public WishlistController(IWishlistService wishlistService)
    {
        _wishlistService = wishlistService;
    }


    public async Task<IActionResult> Index()
    {
        var vm = await _wishlistService.WishListCardVM();
        return View(vm);
    }

    [HttpPost]
    public async Task<IActionResult> AddToWishList(int id)
    {
        await _wishlistService.AddToWishListAsync(id);
        return Json(new { success = true });
    }

    public async Task<IActionResult> WishlistCount()
    {
        var count = await _wishlistService.WishlistCount();
        return Json(new { count = count });
    }
    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _wishlistService.AddToWishListAsync(id);
        return Ok();
    }

}