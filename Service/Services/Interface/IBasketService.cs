using Service.ViewModels.Basket;

namespace Service.Services.Interface;

public interface IBasketService
{
    Task<bool> AddToBasketAsync(int id, int count = 1);
    Task<CardVM> GetBasketAsync();
    Task<int> GetBasketCountAsync();
    Task<decimal> GetBasketTotalAsync();
    Task<bool> DecreaseFromBasketAsync(int productId);
    Task<bool> RemoveAllFromBasketAsync(int productId);

}