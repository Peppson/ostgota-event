using System.ComponentModel.DataAnnotations;

namespace BlazorStandAlone.Models;

public class UserRegister
{
    [Required(ErrorMessage = "Username is required"),]
    [StringLength(30, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 30 characters")]
    public required string Username { get; set; }
    [Required(ErrorMessage = "Password is required")]
    public required string Password { get; set; }
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public required string Email { get; set; }
    public string? PhoneNumber { get; set; }
}
