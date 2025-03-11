namespace Data.Models;

public class User
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public required string PasswordHash { get; set; }
    public required string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public UserRoles Role { get; set; } = UserRoles.User;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public required List<Ticket> Tickets { get; set; }


    public void AddTicket(Ticket ticket)
    {   
        Tickets.Add(ticket);
    }

    public bool RemoveTicket(Ticket ticket)
    {   
        Tickets.RemoveAll(e => e.Id == ticket.Id);

    }

    public void RemoveTicket(int ticketId)
    {   
        Tickets.RemoveAll(e => e.Id == ticketId);
    }
}
