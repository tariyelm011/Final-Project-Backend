﻿using AutoMapper;
using Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Repository.Repositories.Interface;
using Service.Helpers.Exceptions;
using Service.Services.Interface;
using Service.ViewModels.Wishlist;
using System.Security.Claims;

namespace Service.Services;

public class WishlistService : IWishlistService
{
    private readonly IWishlistRepository _wishListItemRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IProductService _productService;

    public WishlistService(IWishlistRepository wishListItemRepository, IHttpContextAccessor httpContextAccessor, IProductService productService)
    {
        _wishListItemRepository = wishListItemRepository;
        _httpContextAccessor = httpContextAccessor;
        _productService = productService;
    }

    public async Task<bool> AddToWishListAsync(int id)
    {
        var product = await _productService.GetAsync(id);
        if (product == null)
            throw new NotFoundException("Product not found!");

        var user = _httpContextAccessor.HttpContext!.User;
        var isAuthenticated = user.Identity != null && user.Identity.IsAuthenticated;

        if (isAuthenticated)
        {
            string userId = user.FindFirst(ClaimTypes.NameIdentifier)!.Value;

            var existingItem = await _wishListItemRepository.GetAsync(x => x.ProductId == id && x.AppUserId == userId);
            if (existingItem != null)
            {
                await _wishListItemRepository.Delete(existingItem);
                await _wishListItemRepository.SaveChangesAsync();
            }
            else
            {
                WishlistItem wishListItem = new WishlistItem
                {
                    AppUserId = userId,
                    ProductId = id
                };
                await _wishListItemRepository.CreateAsync(wishListItem);
                await _wishListItemRepository.SaveChangesAsync();
            }
        }
        else
        {
            var cookies = _httpContextAccessor.HttpContext.Response.Cookies;
            var requestCookies = _httpContextAccessor.HttpContext.Request.Cookies;

            List<WishListCookieItem> wishList = new List<WishListCookieItem>();

            string? cookieData = requestCookies["wishlist"];
            if (!string.IsNullOrEmpty(cookieData))
            {
                wishList = JsonConvert.DeserializeObject<List<WishListCookieItem>>(cookieData) ?? new List<WishListCookieItem>();
            }

            var existingCookieItem = wishList.FirstOrDefault(x => x.ProductId == id);
            if (existingCookieItem != null)
            {
                wishList.Remove(existingCookieItem);
            }
            else
            {
                wishList.Add(new WishListCookieItem
                {
                    ProductId = id
                });
            }

            string updatedCookie = JsonConvert.SerializeObject(wishList);
            cookies.Append("wishlist", updatedCookie, new CookieOptions
            {
                Expires = DateTime.Now.AddDays(14),
                HttpOnly = false,
                Secure = false
            });
        }

        return true;
    }

    public async Task<int> WishlistCount()
    {
        var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId is not null)
        {
            var wishlistItems = _wishListItemRepository
                .GetFilter(x => x.AppUserId == userId)
                .ToList();

            return wishlistItems.Count;
        }
        else
        {
            var cookie = _httpContextAccessor.HttpContext?.Request.Cookies["wishlist"];
            if (!string.IsNullOrWhiteSpace(cookie))
            {
                var cookieItems = JsonConvert.DeserializeObject<List<WishListCookieItem>>(cookie);
                return cookieItems?.Count ?? 0;
            }
        }

        return 0;
    }


    public async Task<WishListCardVM> WishListCardDto()
    {
        var result = new WishListCardVM
        {
            Prroduct = new List<WishlistItemCard>()
        };

        var user = _httpContextAccessor.HttpContext?.User;
        var isAuthenticated = user?.Identity != null && user.Identity.IsAuthenticated;

        if (isAuthenticated)
        {
            string userId = user.FindFirst(ClaimTypes.NameIdentifier)!.Value;

            var wishlistItems = _wishListItemRepository
                .GetFilter(x => x.AppUserId == userId, include: x => x.Include(p => p.Product))
                .ToList();

            result.Prroduct = wishlistItems.Select(x => new WishlistItemCard
            {
                ProductId = x.ProductId,
                Name = x.Product?.Name,
                ImageUrl = x.Product?.ImageUrl,
                Price = x.Product?.Price ?? 0
            }).ToList();
        }
        else
        {
            var cookie = _httpContextAccessor.HttpContext?.Request.Cookies["wishlist"];
            if (!string.IsNullOrWhiteSpace(cookie))
            {
                var cookieItems = JsonConvert.DeserializeObject<List<WishListCookieItem>>(cookie);
                if (cookieItems != null)
                {
                    foreach (var item in cookieItems)
                    {
                        var product = await _productService.GetAsync(item.ProductId);
                        if (product != null)
                        {
                            result.Prroduct.Add(new WishlistItemCard
                            {
                                ProductId = product.Id,
                                Name = product.Name,
                                ImageUrl = product.ImageUrl,
                                Price = product.Price
                            });
                        }
                    }
                }
            }
        }

        return result;
    }


}