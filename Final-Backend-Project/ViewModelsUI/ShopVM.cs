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
    }
}
