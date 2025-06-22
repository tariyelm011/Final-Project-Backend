using Domain.Common;
using Domain.Enum;

namespace Domain.Entity;

public class Payment : BaseEntity
{
    public Order Order { get; set; } = null!;
    public int OrderId { get; set; }
    public int ReceptId { get; set; }
    public string SecretId { get; set; } = null!;
    public PaymentStatuses PaymentStatus { get; set; }
    public decimal Amount { get; set; }
    public string? Description { get; set; }
    public string ConfirmToken { get; set; } = null!;
}
