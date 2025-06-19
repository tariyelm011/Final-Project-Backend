using Domain.Entity;
using Repository.Data;
using Repository.Repositories.Generic;
using Repository.Repositories.Interface;

namespace Repository.Repositories;

internal class ContactRepository : BaseRepository<Contact>, IContactRepository
{
    public ContactRepository(AppDbContext context) : base(context)
    {
    }
}
