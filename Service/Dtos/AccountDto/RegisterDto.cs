using System.ComponentModel.DataAnnotations;

namespace Service.Dtos.AccountDto;

public class RegisterDto
{
    public string UserName { get; set; } = null!;
    public string FullName  { get; set; } = null!;

    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;
    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
    public string ConfirmPassword { get; set; } = null!;
}
