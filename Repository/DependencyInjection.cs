using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.Data;
using Repository.DataInitalizers;
using Repository.Repositories;
using Repository.Repositories.Generic;
using Repository.Repositories.Interface;
using Repository.Repositories.Interface.Generic;

namespace Repository;

public static class DependencyInjection
{
    public static IServiceCollection AddRepositoryLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<DbContextInitalizer>();

        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default")));

        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

        services.AddScoped<IProductRepository, ProductRepository>();

        services.AddScoped<IProductImageRepository, ProductImageRepository>();

        services.AddScoped<ICategoryRepository, CategoryRepository>();

        services.AddScoped<ISliderRepository, SliderRepository>();

        services.AddScoped<ISettingRepository, SettingRepository>();

        services.AddScoped<ISubscribeRepository, SubscribeRepository>();

        services.AddScoped<IBlogRepository, BlogRepository>();

        services.AddScoped<IBrandRepository, BrandRepository>();

        services.AddScoped<IAdvertisementRepository, AdvertisementRepository>();

        services.AddScoped<IExpertRepository, ExpertRepository>();

        services.AddScoped<IAboutUsRepository, AboutUsRepository>();

        services.AddScoped<IContactRepository, ContactRepository>();

        services.AddScoped<IBasketRepository, BasketRepository>();

        services.AddScoped<IWishlistRepository, WishlistRepository>();

        services.AddScoped<IOrderRepository, OrderRepository>();

        services.AddScoped<IOrderItemRepository, OrderItemRepository>();

        services.AddScoped<IStatusRepository, StatusRepository>();

        services.AddScoped<IFeaturedProductRepository, FeaturedProductRepository>();


        return services;
    }
}
