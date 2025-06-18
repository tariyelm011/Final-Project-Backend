using Domain.Entity;
using Repository.Data;
using Repository.Repositories.Generic;
using Repository.Repositories.Interface;

namespace Repository.Repositories;

internal class ExpertRepository : BaseRepository<Expert>, IExpertRepository
{
    public ExpertRepository(AppDbContext context) : base(context)
    {
    }
}
