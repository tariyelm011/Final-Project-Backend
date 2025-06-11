using Domain.Common;

namespace Domain.Entity
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;

        public DateTime? CreatedDate { get; set; }
        public DateTime? EditDate { get; set; }

    }
}