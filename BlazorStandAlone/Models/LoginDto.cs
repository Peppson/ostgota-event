using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace BlazorStandAlone.Models;

public class LoginDto
{
    [Required(ErrorMessage = "Username is required")]
    [StringLength(30, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 30 characters")]
    [JsonPropertyName("username")]
    public string Username { get; set; } = string.Empty;
}
