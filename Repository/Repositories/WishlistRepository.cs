using Domain.Entity;
using Repository.Data;
using Repository.Repositories.Generic;
using Repository.Repositories.Interface;

namespace Repository.Repositories;

internal class WishlistRepository : BaseRepository<WishlistItem>, IWishlistRepository
{
    public WishlistRepository(AppDbContext context) : base(context)
    {
    }
}
