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


    public void BuyTickets(Event currentEvent, int quantity, Ticket ticket)
    {
        if (quantity <= 0)
            throw new ArgumentException("K�p m�ste vara mer �n ett");

        if (currentEvent.RemainingTickets < quantity)
            throw new InvalidOperationException("Inte tillr�ckligt m�nga biljetter kvar!");

        _tickets.Add(ticket);
        currentEvent.RegisterTicket(quantity);
    }

    public void CancelTickets(Event currentEvent, int quantity = 1)
    {
        if (quantity <= 0)
            throw new ArgumentException("Antalet biljetter att avboka m�ste vara st�rre �n 0.");

        // filter out the users tickets for the current event and take the quantity to cancel
        var ticketsToRemove = _tickets
            .Where(t => t.EventId == currentEvent.Id && t.UserId == this.Id)
            .Take(quantity)
            .ToList();

        foreach (var ticket in ticketsToRemove)
        {
            _tickets.Remove(ticket);
        }

        // Update the ticket count
        currentEvent.CancelTicket(quantity);
    }
}

public enum UserRole
{
    Admin,
    User
}
