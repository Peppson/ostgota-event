using System.ComponentModel.DataAnnotations;

namespace Blazor.Models
{
    public class UserDto
    {
        public required string Username { get; set; }
        public UserRole Role { get; set; }
    }
}
