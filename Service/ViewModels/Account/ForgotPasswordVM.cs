using System.ComponentModel.DataAnnotations;

namespace Service.Dtos.AccountDto;

public class ForgotPasswordVM
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;
}
