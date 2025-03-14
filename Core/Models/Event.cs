namespace Core.Models;

public class Event
{
    [Key]
    public int Id { get; set; }
    [Required]
    public required string Name { get; set; }
    [Required]
    public required string Description { get; set; }
    [Required]
    public required string City { get; set; }
    [Required]
    public required string Adress { get; set; }
    [Required]
    public AccessType AccessType { get; set; }
    [Required]
    public DateTime StartTime { get; set; }
    [Required]
    public DateTime EndTime { get; set; }
    public bool HasSeat { get; set; } = false;
    public string? ImagePath { get; set; }  // What to do if no path? Default background? < si senor, me parece bien
    [Required]
    public int TicketsMax { get; set; }
    [Required]
    public int TicketsSold { get; set; } = 0;
    public int RemainingTickets => TicketsMax - TicketsSold;
    public bool IsSoldOut => RemainingTickets == 0;


    public void RegisterTicket()
    {
        if (RemainingTickets > 0) 
            TicketsSold++;
    }

    public void CancelTicket()
    {
        if (TicketsSold >= 1)
            TicketsSold--;
    }
}

public enum AccessType
{
    Free,
    Paid,
    MemberOnly
}
