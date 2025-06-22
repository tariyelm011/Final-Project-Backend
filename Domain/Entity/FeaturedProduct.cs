using Domain.Common;

namespace Domain.Entity
{
    public class FeaturedProduct : BaseEntity
    {
        public int ProductId { get; set; } 
        public Product Product { get; set; }

        public decimal DiscountedPrice { get; set; } 
        public decimal OrginalPrice { get; set; } 

        public DateTime CountdownEndDate { get; set; } 
    }
}
