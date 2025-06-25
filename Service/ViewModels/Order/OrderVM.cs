using Service.ViewModels.OrderItem;

namespace Service.ViewModels.Order;

public class OrderVM
{
    public int Id { get; set; }

    public string? AppUserId { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string City { get; set; } = null!;

    public string? Apartment { get; set; }

    public string? CompanyName { get; set; }

    public string Street { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public decimal TotalPrice { get; set; }

    public bool IsPaid { get; set; }

    public string StatusName { get; set; } = null!;

    public List<OrderItemVM> OrderItems { get; set; } = new();
}
