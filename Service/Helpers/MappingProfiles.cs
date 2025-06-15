using AutoMapper;
using Domain.Entity;
using Service.Dtos.Blog;
using Service.Dtos.Brand;
using Service.Dtos.Category;
using Service.Dtos.Product;
using Service.Dtos.ProductImage;
using Service.Dtos.Setting;
using Service.Dtos.Slider;
using Service.Dtos.Subscribe;
using System.Linq;

namespace Service.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Category, CategoryCreateDto>().ReverseMap();
        CreateMap<Category, CategoryEditDto>().ReverseMap();

        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<Product, ProductCreateDto>().ReverseMap();
        CreateMap<Product, ProductEditDto>().ReverseMap();


        CreateMap<ProductImage, ProductImageDto>().ReverseMap();
        CreateMap<ProductImage, ProductImageCreateDto>().ReverseMap();
        CreateMap<ProductImage, ProductImageEditDto>().ReverseMap();

        CreateMap<Slider, SliderDto>().ReverseMap();
        CreateMap<Slider, SliderCreateDto>().ReverseMap();
        CreateMap<Slider, SliderEditDto>().ReverseMap();

        CreateMap<Setting, SettingCreateDto>().ReverseMap();
        CreateMap<Setting, SettingDto>().ReverseMap();
        CreateMap<Setting, SettingEditDto>().ReverseMap();


        CreateMap<Subscribe, SubscribeDto>().ReverseMap();
        CreateMap<Subscribe, SubscribeCreateDto>().ReverseMap();
        CreateMap<Subscribe, SubscribeEditDto>().ReverseMap();


        CreateMap<Blog, BlogDto>().ReverseMap();
        CreateMap<Blog, BlogCreateDto>().ReverseMap();
        CreateMap<Blog, BlogEditDto>().ReverseMap();

        CreateMap<Brand, BrandDto>().ReverseMap();
        CreateMap<Brand, BrandCreateDto>().ReverseMap();
        CreateMap<Brand, BrandEditDto>().ReverseMap();

    }
}
