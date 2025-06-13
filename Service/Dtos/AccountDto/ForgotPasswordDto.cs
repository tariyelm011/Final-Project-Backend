using System.ComponentModel.DataAnnotations;

namespace Service.Dtos.AccountDto;

public class ForgotPasswordDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;
}
