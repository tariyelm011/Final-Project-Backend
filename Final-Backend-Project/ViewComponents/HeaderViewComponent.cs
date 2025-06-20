using Final_Backend_Project.ViewModelsUI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Service.Services;
using Service.Services.Interface;

namespace Final_Backend_Project.ViewComponents;

public class HeaderViewComponent : ViewComponent
{

    private readonly IBasketService _basketService;
    private readonly IWishlistService _wishlistService;

    public HeaderViewComponent(IBasketService basketService, IWishlistService wishlistService)
    {
        _basketService = basketService;
        _wishlistService = wishlistService;
    }

    public async Task<ViewViewComponentResult> InvokeAsync()
    {
        var count = await _basketService.GetBasketCountAsync();
        var total = await _basketService.GetBasketTotalAsync();
        var wishlistCount = await _wishlistService.WishlistCount();



        HeaderVM headerVM = new HeaderVM { BasketCount = count, BasketTotal = total, WishListCount = wishlistCount };

        return View(headerVM);
    }
}

