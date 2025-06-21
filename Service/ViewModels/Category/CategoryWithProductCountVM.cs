namespace Service.Dtos.Category;

public class CategoryWithProductCountVM
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public int ProductCount { get; set; }
}