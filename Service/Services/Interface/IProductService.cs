using Domain.Entity;
using Service.Dtos.Product;
using Service.Services.Interface.Generic;

namespace Service.Services.Interface;

public interface IProductService : ICrudService<Product, ProductCreateDto, ProductEditDto, ProductDto>
{
    Task<(bool Success, List<string> Errors)> ProductCreate(ProductCreateDto dto);
    Task<ProductCreateDto> GetCreatedProductDto();
    Task<ProductEditDto> GetProductUpdateDto(int productId);
    Task<(bool Success, List<string> Errors)> UpdateProductAsync(ProductEditDto dto);


}
