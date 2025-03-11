namespace Data.Models;

public class User
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public required string PasswordHash { get; set; }
    public UserRoles Role { get; set; } = UserRoles.User;
    public required string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


    public List<Ticket>? Tickets { get; set; } = null; // Todo relation <<<<<<

    public void AddTicket(Ticket ticket)
    {
        Tickets.Add(ticket);
    }

    // RM

    // todo
}

public enum UserRoles
{
    Admin,
    User
}
