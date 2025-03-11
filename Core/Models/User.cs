namespace Data.Models;

public class User
{   
    [Key]
    public int Id { get; set; }
    [Required]
    public string Username { get; set; }
    [Required]
    public string PasswordHash { get; set; }
    [Required]
    public string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public UserRoles Role { get; set; } = UserRoles.User;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public List<Ticket> Tickets { get; set; } = [];
}
