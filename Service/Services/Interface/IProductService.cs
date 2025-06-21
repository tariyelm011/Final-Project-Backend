using Domain.Entity;
using Service.Dtos.Product;
using Service.Helpers.Exceptions;
using Service.Services.Interface.Generic;

namespace Service.Services.Interface;

public interface IProductService : ICrudService<Product, ProductCreateVM, ProductEditVM, ProductVM>
{
    Task<(bool Success, List<string> Errors)> CreateAsync(ProductCreateVM dto);
    Task<ProductCreateVM> CreateProductVM();
    Task<ProductEditVM> ProductUpdateVM(int productId);
    Task<(bool Success, List<string> Errors)> UpdateAsync(ProductEditVM dto);

    Task<PaginationResponse<ProductVM>> GetPaginateAsync(int page, int take);
    Task<List<ProductVM>> GetLatestProductsAsync();

    Task<PaginationResponse<ProductVM>> GetFilteredPaginatedProductsAsync( string? search,string? sort,int? categoryId,int page,int take);


}
