﻿using Microsoft.AspNetCore.Mvc;
using Service.Services;
using Service.Services.Interface;

namespace Final_Backend_Project.Controllers;

public class BasketController : Controller
{
    private readonly IBasketService _basketService;

    public BasketController(IBasketService basketService)
    {
        _basketService = basketService;
    }

    [HttpPost]
    public async Task<IActionResult> AddToBasket(int id)
    {
        await _basketService.AddToBasketAsync(id);

        var count = await _basketService.GetBasketCountAsync();
        var total = await _basketService.GetBasketTotalAsync();

        return Json(new { success = true, count = count, total = total });
    }


    public async Task<IActionResult> Index()
    {
        var basketItems = await _basketService.GetBasketAsync();

        return View(basketItems);
    }
    [HttpPost]

    public async Task<IActionResult> Deacrease(int id)
    {
        await _basketService.DecreaseFromBasketAsync(id);
        var count = await _basketService.GetBasketCountAsync();
        var total = await _basketService.GetBasketTotalAsync();

        return Json(new { success = true, count = count, total = total });
    }

    public async Task<IActionResult> Delete(int id)
    {
        await _basketService.RemoveAllFromBasketAsync(id);

        return RedirectToAction("index");
    }

    public async Task<IActionResult> GetCountAndTotal()
    {
        var count = await _basketService.GetBasketCountAsync();
        var total = await _basketService.GetBasketTotalAsync();

        return Json(new { count = count, total = total });
    }

    [HttpGet]
    public async Task<IActionResult> GetProduct(int id)
    {
        var cardDto = await _basketService.GetBasketAsync();
        var product = cardDto.Prroduct.FirstOrDefault(p => p.ProductId == id);

        if (product == null) return NotFound();

        return Ok(new
        {
            count = product.Count,
            totalPrice = product.TotalProductPrice
        });
    }


}