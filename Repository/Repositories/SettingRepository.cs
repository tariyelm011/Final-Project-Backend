using Domain.Entity;
using Repository.Data;
using Repository.Repositories.Generic;
using Repository.Repositories.Interface;

namespace Repository.Repositories;

internal class SettingRepository : BaseRepository<Setting>, ISettingRepository
{
    private readonly AppDbContext _context;
    public SettingRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public string GetSettingByKey(string key)
    {
        return _context.Settings
                       .Where(s => s.Key == key)
                       .Select(s => s.Value)
                       .FirstOrDefault();
    }

}
