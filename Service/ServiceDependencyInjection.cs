﻿using Microsoft.Extensions.DependencyInjection;
using Service.Services.Interface;
using Service.Services;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Service
{
    public static class ServiceDependencyInjection
    {
        public static IServiceCollection AddBllServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<IProductImageService, ProductImageService>();

            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<ISliderService, SliderService>();

            services.AddScoped<ISubscribeService, SubscribeService>();

            services.AddScoped<ISettingService, SettingService>();

            services.AddScoped<ICloudinaryManager, CloudinaryManager>();

            services.AddScoped<IEmailService, EmailService>();

            services.AddScoped<IAccountService, AccountService>();

            services.AddScoped<IBlogService, BlogService>();

            services.AddScoped<IBrandService, BrandService>();

            services.AddScoped<IExpertService, ExpertService>();

            services.AddScoped<IAdvertisementService, AdvertisementService>();

            services.AddScoped<IAboutUsService, AboutUsService>();

            services.AddScoped<IContactService, ContactService>();

            services.AddScoped<IWishlistService, WishlistService>();

            services.AddScoped<IBasketService, BasketService>();

            services.AddScoped<IFeaturedProductService, FeaturedProductService>();

            services.AddScoped<IOrderService, OrderService>();

            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            services.AddScoped<IPaymentService, PaymentService>();






            return services;
        }
    }
}
