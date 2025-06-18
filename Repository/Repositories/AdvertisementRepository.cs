using Domain.Entity;
using Repository.Data;
using Repository.Repositories.Generic;
using Repository.Repositories.Interface;

namespace Repository.Repositories;

internal class AdvertisementRepository : BaseRepository<Advertisement>, IAdvertisementRepository
{
    public AdvertisementRepository(AppDbContext context) : base(context)
    {
    }
}
