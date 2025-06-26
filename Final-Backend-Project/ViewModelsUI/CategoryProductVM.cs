using Service.Dtos.Category;
using Service.Dtos.Product;

namespace Final_Backend_Project.ViewModelsUI
{
    public class CategoryProductVM
    {
        public List <ProductVM> Products { get; set; } = new List<ProductVM>();
        public List <CategoryVM> Categories { get; set; } = new List<CategoryVM>();

    }
}
