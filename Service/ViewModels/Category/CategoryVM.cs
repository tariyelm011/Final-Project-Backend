﻿using Service.Dtos.Common;

namespace Service.Dtos.Category;

public class CategoryVM 
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public int ProductId { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? EditDate { get; set; }
}
