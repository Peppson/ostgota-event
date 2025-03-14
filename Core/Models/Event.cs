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
    public required string Address { get; set; }
    [Required]
    public AccessType AccessType { get; set; }
    [Required]
    public DateTime StartTime { get; set; }
    [Required]
    public DateTime EndTime { get; set; }
    public bool HasSeat { get; set; } = false;
    [Required]
    public required string ImagePath { get; set; } = "images/Knight.jpg";
    public int? TicketsMax { get; set; }
    [Required]
    public required int TicketsSold { get; set; } = 0;
    public int RemainingTickets
    {
        get
        {
            if (TicketsMax.HasValue)
            {
                return TicketsMax.Value - TicketsSold;
            }
            return int.MaxValue; 
        }
    }

    public bool IsSoldOut
    {
        get
        {
            if (TicketsMax.HasValue)
            {
                return RemainingTickets == 0;
            }
            return false; 
        }
    }

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

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AccessType
{
    Free,
    Paid,
    MemberOnly
}
