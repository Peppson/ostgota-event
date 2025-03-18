using System.ComponentModel.DataAnnotations;

namespace BlazorStandAlone.Models
{
    public class RegisterUserDto
    {
        public RegisterUserDto(string username, string email, string phoneNumber, UserRole role)
        {
            Username = username;
            Email = email;
            PhoneNumber = phoneNumber;
            Role = role;
        }
        
        [Required(ErrorMessage = "Username is required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 30 characters")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = string.Empty;

        [Phone(ErrorMessage = "Invalid phone number")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Role is required")]
        public UserRole Role { get; set; }
    }
}
