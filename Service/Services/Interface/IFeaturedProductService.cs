using Domain.Entity;
using Service.Services.Interface.Generic;
using Service.ViewModels.FeaturedProduct;

namespace Service.Services.Interface;

public interface IFeaturedProductService : ICrudService<FeaturedProduct, FeaturedProductCreateVM, FeaturedProductEditVM, FeaturedProductVM>
{
    Task CreateAsync(FeaturedProductCreateVM vm);
    Task<List<FeaturedProductVM>> FeaturedProductsAsync();
    Task EditAsync(FeaturedProductEditVM vm);
    Task<FeaturedProductEditVM> GetByIdForEditAsync(int id);
    Task RestoreOrginalPrice(int productId);
}

