using System.ComponentModel.DataAnnotations;

namespace BlazorStandAlone.Models;

public class UserDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Username is required"), ]
    [StringLength(30, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 30 characters")]
    public required string Username { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public required string Email { get; set; }

    [Phone(ErrorMessage = "Invalid phone number")]
    public string? PhoneNumber { get; set; }

    public List<TicketDto>? Tickets { get; set; }

    [Required(ErrorMessage = "Creation date is required")]
    public DateTime CreatedAt { get; set; }

    [Required(ErrorMessage = "Role is required")]
    public UserRole Role { get; set; }
}
