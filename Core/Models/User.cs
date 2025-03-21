namespace Core.Models;

public class User
{
    [Key]
    public int Id { get; set; }
    [Required]
    public required string Username { get; set; }
    [Required]
    public required string PasswordHash { get; set; }
    [Required]
    public required string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public UserRole Role { get; set; } = UserRole.User;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public List<Ticket> Tickets { get; set; } = [];

    public void BuyTicket(Ticket ticket)
    {   
        if (ticket.Event.RemainingTickets > 0)
            Tickets.Add(ticket);
    }

    public void RemoveTicket(Ticket ticket)
    {   
        if (Tickets.Count > 0)
            Tickets.Remove(ticket);
    }
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum UserRole
{
    Admin,
    User
}
