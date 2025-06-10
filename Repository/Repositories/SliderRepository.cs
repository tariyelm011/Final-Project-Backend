using Domain.Entity;
using Repository.Data;
using Repository.Repositories.Generic;
using Repository.Repositories.Interface;

namespace Repository.Repositories;

internal class SliderRepository : BaseRepository<Slider>, ISliderRepository
{
    public SliderRepository(AppDbContext context) : base(context)
    {
    }
}
