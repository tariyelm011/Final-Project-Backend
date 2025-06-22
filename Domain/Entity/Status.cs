using Domain.Common;

namespace Domain.Entity;

public class Status : BaseEntity
{
    public ICollection<Order> Orders { get; set; } = [];
    public string Name { get; set; } = null!;

 
}