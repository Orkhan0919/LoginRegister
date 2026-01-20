using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels.Identity;

public class LoginVM
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}