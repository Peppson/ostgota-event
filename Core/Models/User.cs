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
    private List<Ticket> _tickets = new List<Ticket>();
    public IReadOnlyCollection<Ticket> Tickets => _tickets.AsReadOnly();


    public void BuyTickets(Ticket ticket)
    {
        _tickets.Add(ticket);
    }

    public void CancelTickets(Ticket ticket, Event event1)
    {
        _tickets.Remove(ticket);
        
        // Update the ticket count
        event1.CancelTicket();
    }
}

public enum UserRole
{
    Admin,
    User
}
