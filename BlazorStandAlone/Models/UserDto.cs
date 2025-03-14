using System.ComponentModel.DataAnnotations;

namespace BlazorStandAlone.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public List<Ticket> Tickets { get; set; }
        public UserRole Role { get; set; }
    }
}
