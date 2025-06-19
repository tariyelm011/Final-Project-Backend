using Domain.Entity;
using Service.Dtos.ProductImage;
using Service.Services.Interface.Generic;

namespace Service.Services.Interface;

public interface IProductImageService : ICrudService<ProductImage, ProductImageCreateVM, ProductImageEditVM, ProductImageVM>
{
}
