using System.ComponentModel.DataAnnotations;

namespace lab13.ViewModels;

public class LoginViewModel
{
    [Required] [EmailAddress] public required string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public required string Password { get; set; }

    [Display(Name = "Запомнить меня")] public bool RememberMe { get; set; }
}
