using Domain.Common;

namespace Domain.Entity
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string VideoUrl { get; set; } = null!;
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? EditDate { get; set; }
        public List<ProductImage>? ProductImages { get; set; } = [];
    }
     
}
