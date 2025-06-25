using Domain.Entity;
using Repository.Data;
using Repository.Repositories.Generic;
using Repository.Repositories.Interface;

namespace Repository.Repositories;

internal class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
{
    public PaymentRepository(AppDbContext context) : base(context)
    {
    }
}
