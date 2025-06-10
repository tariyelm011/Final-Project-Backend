using Domain.Entity;
using Repository.Data;
using Repository.Repositories.Generic;
using Repository.Repositories.Interface;

namespace Repository.Repositories;

internal class SettingRepository : BaseRepository<Setting>, ISettingRepository
{
    public SettingRepository(AppDbContext context) : base(context)
    {
    }
}
