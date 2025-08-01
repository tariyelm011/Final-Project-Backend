﻿using AutoMapper;
using Domain.Entity;
using Repository.Repositories.Interface;
using Service.Dtos.ProductImage;
using Service.Services.Generic;
using Service.Services.Interface;

namespace Service.Services;

public class ProductImageService : CrudService<ProductImage, ProductImageCreateVM, ProductImageEditVM, ProductImageVM>, IProductImageService
{
    public ProductImageService(IProductImageRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }


}
