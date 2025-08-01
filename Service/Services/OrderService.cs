﻿using AutoMapper;
using Domain.Entity;
using Microsoft.AspNetCore.Http;
using Repository.Repositories.Interface;
using Service.Helpers.Exceptions;
using Service.Services.Generic;
using Service.Services.Interface;
using Service.ViewModels.Order;
using Service.ViewModels.Payment;

namespace Service.Services;

public class OrderService : CrudService<Order, OrderCreateVM, OrderEditVM, OrderVM>, IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;
    private readonly IBasketService _basketService;
    private readonly IPaymentService _paymentService;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IProductService _productService;
    public OrderService(IOrderRepository repository, IMapper mapper, IBasketService basketService, IPaymentService paymentService, IHttpContextAccessor httpContextAccessor, IProductService productService) : base(repository, mapper)
    {
        _orderRepository = repository;
        _mapper = mapper;
        _basketService = basketService;
        _paymentService = paymentService;
        _httpContextAccessor = httpContextAccessor;
        _productService = productService;
    }

    public async Task CreateOrderAsync(OrderCreateVM dto)
    {
        var card = await _basketService.GetBasketOrderAsync();

        var orderItems = card.Prroduct.Select(item => new OrderItem
        {
            ProductId = item.ProductId,
            Count = item.Count,
            TotalPrice = item.TotalProductPrice
        }).ToList();

        var productIds = card.Prroduct.Select(x => x.ProductId).ToList();
        var products = await _productService.GetAllAsync(x => productIds.Contains(x.Id));

        foreach (var item in card.Prroduct)
        {
            var product = products.FirstOrDefault(p => p.Id == item.ProductId);

            if (product == null)
                throw new Exception("Məhsul tapılmadı.");

            if (product.Stock < item.Count || product.Stock <= 0)
                return;
        }




        var order = new Order
        {
            AppUserId = dto.AppUserId,
            Name = dto.Name,
            Surname = dto.Surname,
            City = dto.City,
            Apartment = dto.Apartment,
            CompanyName = dto.CompanyName,
            Street = dto.Street,
            PhoneNumber = dto.PhoneNumber,
            Email = dto.Email,
            StatusId = 1,
            IsPaid = false,
            CreatedDate = DateTime.UtcNow,
            OrderItems = orderItems,
            TotalPrice = card.TotalAmount
        };

        await _orderRepository.CreateAsync(order);



        PaymentCreateVM paymentvm = new()
        {
            Description = "Motordoctor Odenis",
            Amount = order.TotalPrice,
            OrderId = order.Id,
        };

        var responseDto = await _paymentService.CreateAsync(paymentvm);

        order.PaymentId = responseDto.Id;

        _orderRepository.Update(order);
        await _orderRepository.SaveChangesAsync();

        if (_httpContextAccessor.HttpContext is not null)
        {
            string paymentUrl = $"{responseDto.Order.HppUrl}?id={responseDto.Order.Id}&password={responseDto.Order.Password}";
            _httpContextAccessor.HttpContext.Response.Cookies.Append("paymentUrl", paymentUrl, new CookieOptions() { Expires = DateTime.UtcNow.AddMinutes(1) });
        }
    }




}
