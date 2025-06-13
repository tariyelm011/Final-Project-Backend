using System.ComponentModel.DataAnnotations;

namespace Service.Dtos.AccountDto;

public class ResetPasswordDto
{
    [Required]
    public string? Token { get; set; }

    [Required]
    [EmailAddress]
    public string? Email { get; set; } = null!;

    [Required]
    [StringLength(100, MinimumLength = 6)]
    [DataType(DataType.Password)]
    public string NewPassword { get; set; } = null!;

    [Required]
    [Compare("NewPassword")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; } = null!;
}
