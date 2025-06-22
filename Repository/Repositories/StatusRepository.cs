using Domain.Entity;
using Repository.Data;
using Repository.Repositories.Generic;
using Repository.Repositories.Interface;

namespace Repository.Repositories;

internal class StatusRepository : BaseRepository<Status>, IStatusRepository
{
    public StatusRepository(AppDbContext context) : base(context)
    {
    }
}
