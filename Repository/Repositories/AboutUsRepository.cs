using Domain.Entity;
using Repository.Data;
using Repository.Repositories.Generic;
using Repository.Repositories.Interface;

namespace Repository.Repositories;

internal class AboutUsRepository : BaseRepository<AboutUs>, IAboutUsRepository
{
    public AboutUsRepository(AppDbContext context) : base(context)
    {
    }
}
