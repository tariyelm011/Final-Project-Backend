using Domain.Common;

namespace Domain.Entity
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public int ProductId { get; set; } 
        public Product? Product { get; set; }

    }
}
