using System.ComponentModel.DataAnnotations;

namespace Service.Dtos.AccountDto;

public class LoginDto
{
    public string Email { get; set; } = null!;
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;
}
