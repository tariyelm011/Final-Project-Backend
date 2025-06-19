using Domain.Entity;
using Repository.Data;
using Repository.Repositories.Generic;
using Repository.Repositories.Interface;

namespace Repository.Repositories;

internal class BasketRepository : BaseRepository<BasketItem>, IBasketRepository
{
    public BasketRepository(AppDbContext context) : base(context)
    {
    }
}
