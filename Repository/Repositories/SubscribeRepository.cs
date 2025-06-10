using Domain.Entity;
using Repository.Data;
using Repository.Repositories.Generic;
using Repository.Repositories.Interface;

namespace Repository.Repositories;

internal class SubscribeRepository : BaseRepository<Subscribe>, ISubscribeRepository
{
    public SubscribeRepository(AppDbContext context) : base(context)
    {
    }
}