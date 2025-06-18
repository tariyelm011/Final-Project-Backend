using Microsoft.AspNetCore.Http;
using Service.Dtos.Common;

namespace Service.Dtos.Expert;

public class ExpertCreateVM : IDto
{
    public string Name { get; set; } = null!;
    public string Job { get; set; } = null!;
    public IFormFile Image { get; set; } = null!;
}


