using Domain.Entity;
using Repository.Data;
using Repository.Repositories.Generic;
using Repository.Repositories.Interface;

namespace Repository.Repositories;

internal class FeaturedProductRepository : BaseRepository<FeaturedProduct>, IFeaturedProductRepository
{
    public FeaturedProductRepository(AppDbContext context) : base(context)
    {
    }
}