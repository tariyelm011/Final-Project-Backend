using Domain.Common;

namespace Domain.Entity;

public class WishlistItem : BaseEntity
{
    public Product Product { get; set; } = null!;
    public int ProductId { get; set; }
    public AppUser AppUser { get; set; } = null!;
    public string AppUserId { get; set; } = null!;
}

public class WishlistItemCard
{
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public decimal Price { get; set; }
}
