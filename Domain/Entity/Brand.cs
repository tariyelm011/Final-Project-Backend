using Domain.Common;

namespace Domain.Entity;

public class Brand : BaseEntity
{
    public string Name { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public List<Product> Products { get; set; } = [];

    public DateTime? CreatedDate { get; set; }
    public DateTime? EditDate { get; set; }

}

