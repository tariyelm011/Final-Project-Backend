using Domain.Entity;

namespace Service.ViewModels.Wishlist;

public class WishListCardVM
{
    public List<WishlistItemCard> Product { get; set; } = new List<WishlistItemCard>();
}
