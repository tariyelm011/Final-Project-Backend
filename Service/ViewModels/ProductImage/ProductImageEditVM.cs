﻿using Microsoft.AspNetCore.Http;
using Service.Dtos.Common;

namespace Service.Dtos.ProductImage;

public class ProductImageEditVM 
{
    public IFormFile? ImageUrl { get; set; }
    public int ProductId { get; set; }
}