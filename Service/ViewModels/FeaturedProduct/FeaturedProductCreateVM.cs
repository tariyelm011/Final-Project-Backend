using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Service.ViewModels.FeaturedProduct;

public class FeaturedProductCreateVM
{
    [Required]
    public int ProductId { get; set; }

    public List<SelectListItem> Products { get; set; } = new();

    [Required]
    [Range(0.01, double.MaxValue)]
    public decimal DiscountedPrice { get; set; }

    [Required]
    public DateTime CountdownEndDate { get; set; }
}
