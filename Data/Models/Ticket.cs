namespace Data.Models;

public class Ticket
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; } // Todo Needed?
    public int EventId { get; set; }
    public Event Event { get; set; } // Todo Needed?
    public string Title { get; set; } = "";
    public decimal Price { get; set; }
    public string? Seat { get; set; } 
}
