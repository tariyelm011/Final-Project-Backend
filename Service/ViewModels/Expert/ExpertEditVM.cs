using Microsoft.AspNetCore.Http;
using Service.Dtos.Common;

namespace Service.Dtos.Expert;

public class ExpertEditVM 
{
    public int Id { get; set; } 
    public string Name { get; set; } = null!;
    public string Job { get; set; } = null!;
    public string Image { get; set; } = null!;
    public IFormFile ImageUrl { get; set; } = null!;
}


