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

    public void BuyTickets(Event currentEvent, int quantity, decimal ticketPrice, string? seat = null)
    {
        if (quantity <= 0)
            throw new ArgumentException("Köp måste vara mer än ett");

        if (currentEvent.RemainingTickets < quantity)
            throw new InvalidOperationException("Inte tillräckligt många biljetter kvar!");


        // Register new tickets
        for (int i = 0; i < quantity; i++)
        {
            var ticket = new Ticket 
            {
                UserId = this.Id,
                User = this,
                EventId = currentEvent.Id,
                Event = currentEvent,
                Price = ticketPrice,
                Seat = seat
            };

            _tickets.Add(ticket);
        }

        currentEvent.RegisterTicket(quantity);
    }

}

public enum UserRole
{
    Admin,
    User
}
