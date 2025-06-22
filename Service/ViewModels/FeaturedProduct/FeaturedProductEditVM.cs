using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Service.ViewModels.FeaturedProduct;

public class FeaturedProductEditVM
{
    [Required]
    public int Id { get; set; }

    [Required]
    public int ProductId { get; set; }

    [Required]
    [Range(0.01, double.MaxValue)]
    public decimal DiscountedPrice { get; set; }

    public List<SelectListItem>? Products { get; set; }
    [Required]
    public DateTime CountdownEndDate { get; set; }
}
