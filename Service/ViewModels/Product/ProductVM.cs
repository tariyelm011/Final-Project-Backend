using Service.Dtos.Category;
using Service.Dtos.Common;
using Service.Dtos.ProductImage;

namespace Service.Dtos.Product;

public class ProductVM
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public int CategoryId { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? EditDate { get; set; }
    public string VideoUrl { get; set; } = null!;
    public List<ProductImageVM>? ProductImages { get; set; } = [];
    public List<CategoryVM> Categories { get; set; } = [];


}
