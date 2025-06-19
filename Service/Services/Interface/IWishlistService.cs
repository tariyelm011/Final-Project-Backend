using Service.ViewModels.Wishlist;

namespace Service.Services.Interface;

public interface IWishlistService
{
    Task<bool> AddToWishListAsync(int id);
    Task<int> WishlistCount();
    Task<WishListCardVM> WishListCardDto();

}