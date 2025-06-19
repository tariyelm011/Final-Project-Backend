using AutoMapper;
using Domain.Entity;
using Service.Dtos.AboutUs;
using Service.Dtos.Advertisement;
using Service.Dtos.Blog;
using Service.Dtos.Brand;
using Service.Dtos.Category;
using Service.Dtos.Expert;
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
        CreateMap<Category, CategoryVM>().ReverseMap();
        CreateMap<Category, CategoryCreateVM>().ReverseMap();
        CreateMap<Category, CategoryEditVM>().ReverseMap();

        CreateMap<Product, ProductVM>().ReverseMap();
        CreateMap<Product, ProductCreateVM>().ReverseMap();
        CreateMap<Product, ProductEditVM>().ReverseMap();


        CreateMap<ProductImage, ProductImageVM>().ReverseMap();
        CreateMap<ProductImage, ProductImageCreateVM>().ReverseMap();
        CreateMap<ProductImage, ProductImageEditVM>().ReverseMap();

        CreateMap<Slider, SliderVM>().ReverseMap();
        CreateMap<Slider, SliderCreateVM>().ReverseMap();
        CreateMap<Slider, SliderEditVM>().ReverseMap();

        CreateMap<Setting, SettingCreateVM>().ReverseMap();
        CreateMap<Setting, SettingVM>().ReverseMap();
        CreateMap<Setting, SettingEditVM>().ReverseMap();


        CreateMap<Subscribe, SubscribeVM>().ReverseMap();
        CreateMap<Subscribe, SubscribeCreateVM>().ReverseMap();
        CreateMap<Subscribe, SubscribeEditVM>().ReverseMap();


        CreateMap<Blog, BlogVM>().ReverseMap();
        CreateMap<Blog, BlogCreateVM>().ReverseMap();
        CreateMap<Blog, BlogEditVM>().ReverseMap();

        CreateMap<Brand, BrandVM>().ReverseMap();
        CreateMap<Brand, BrandCreateVM>().ReverseMap();
        CreateMap<Brand, BrandEditVM>().ReverseMap();


        CreateMap<Advertisement, AdvertisementVM>().ReverseMap();
        CreateMap<Advertisement, AdvertisementCreateVM>().ReverseMap();
        CreateMap<Advertisement, AdvertisementEditVM>().ReverseMap();
        CreateMap<AdvertisementEditVM, Advertisement>();

        CreateMap<Expert, ExpertVM>().ReverseMap();
        CreateMap<Expert, ExpertCreateVM>().ReverseMap();
        CreateMap<Expert, ExpertEditVM>().ReverseMap();

        CreateMap<AboutUs, AboutUsVM>().ReverseMap();
        CreateMap<AboutUs, AboutUsCreateVM>().ReverseMap();
        CreateMap<AboutUs, AboutUsEditVM>().ReverseMap();

    }
}
