using AutoMapper;
using Domain.Entity;
using Repository.Repositories.Interface;
using Service.Dtos.Product;
using Service.Services.Generic;
using Service.Services.Interface;

namespace Service.Services;

public class ProductService : CrudService<Product, ProductCreateDto, ProductEditDto, ProductDto>, IProductService
{
    public ProductService(IProductRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
