namespace Data.Models;

public class Event
{
    public int Id { get; set; }
    public string Name { get; set; } = "New event";
    public string Description { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public AccessType AccessType { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public int TicketsSold { get; set; }
    public int TicketsMax { get; set; }
    public string? ImagePath { get; set; }
    public bool HasSeat { get; set; } = false;
}
