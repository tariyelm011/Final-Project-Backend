using Domain.Entity;
using Service.Dtos.Category;
using Service.Dtos.Product;
using Service.Helpers.Exceptions;

namespace Final_Backend_Project.ViewModelsUI
{
    public class ShopVM
    {
        public PaginationResponse<ProductVM>? Products { get; set; }
        public string? Search { get; set; }
        public string? Sort { get; set; }
        public int? CategoryId { get; set; }
        public List<CategoryVM> Categories { get; set; } = new List<CategoryVM>();
        public List<int>? CategoryIds { get; set; }
        public decimal? PriceFrom { get; set; }
        public decimal? PriceTo { get; set; }

    }
}
