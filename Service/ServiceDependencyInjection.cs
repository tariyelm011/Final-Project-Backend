using Microsoft.Extensions.DependencyInjection;
using Service.Services.Interface;
using Service.Services;
using System.Reflection;

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




            return services;
        }
    }
}
