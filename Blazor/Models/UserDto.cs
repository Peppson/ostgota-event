using System.ComponentModel.DataAnnotations;

namespace Blazor.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        [Required]
        public required string Username { get; set; }
        [Required]
        public required string PasswordHash { get; set; }
        [Required]
        public required string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public UserRole Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<Ticket> Tickets { get; set; }
    }
}
