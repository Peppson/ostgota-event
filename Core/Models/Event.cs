namespace Data.Models;

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
    public AccessType AccessType { get; set; }
    [Required]
    public DateTime StartTime { get; set; }
    [Required]
    public DateTime EndTime { get; set; }
    [Required]
    public int TicketsSold { get; set; }
    [Required]
    public int TicketsMax { get; set; }
    public bool HasSeat { get; set; } = false;
    public string? ImagePath { get; set; } // What to do if no path? Default background?
}
