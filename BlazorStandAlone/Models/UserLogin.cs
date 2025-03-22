using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BlazorStandAlone.Models;

public class UserLogin
{
    [Required(ErrorMessage = "Username is required")]
    [StringLength(30, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 30 characters")]
    public required string Username { get; set; } = string.Empty;

    [Required(ErrorMessage = "Password is required")]
    public required string Password { get; set; } = string.Empty;
}
