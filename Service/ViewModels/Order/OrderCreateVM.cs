using Service.ViewModels.OrderItem;
using System.ComponentModel.DataAnnotations;

namespace Service.ViewModels.Order;

public class OrderCreateVM
{
    public string? AppUserId { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public string Surname { get; set; } = null!;

    [Required]
    public string City { get; set; } = null!;

    public string? Apartment { get; set; }

    public string? CompanyName { get; set; }

    [Required]
    public string Street { get; set; } = null!;

    [Required]
    [Phone]
    public string PhoneNumber { get; set; } = null!;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

    public int StatusId { get; set; }
    public bool IsPaid { get; set; } = true;

    public List<OrderItemVM> OrderItems { get; set; } = new();
}
