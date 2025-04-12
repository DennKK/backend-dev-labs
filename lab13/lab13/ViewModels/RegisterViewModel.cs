using System.ComponentModel.DataAnnotations;

namespace lab13.ViewModels;

public class RegisterViewModel
{
    [Required] [EmailAddress] public required string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public required string Password { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Пароли не совпадают.")]
    public required string ConfirmPassword { get; set; }
}
