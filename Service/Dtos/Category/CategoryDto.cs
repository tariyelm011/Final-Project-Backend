using Service.Dtos.Common;

namespace Service.Dtos.Category;

public class CategoryDto : IDto
{
    public string Name { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public int ProductId { get; set; }
}
