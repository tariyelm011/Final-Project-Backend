using Domain.Entity;
using Service.Dtos.Product;
using Service.Services.Interface.Generic;

namespace Service.Services.Interface;

public interface IProductService : ICrudService<Product, ProductCreateDto, ProductEditDto, ProductDto>
{
  
}
