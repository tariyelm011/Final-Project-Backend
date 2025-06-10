using Domain.Entity;
using Repository.Data;
using Repository.Repositories.Generic;
using Repository.Repositories.Interface;

namespace Repository.Repositories;

internal class ProductImageRepository : BaseRepository<ProductImage>, IProductImageRepository
{
    public ProductImageRepository(AppDbContext context) : base(context)
    {
    }
}
