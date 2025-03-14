using System.ComponentModel.DataAnnotations;

namespace BlazorStandAlone.Models;

public class EventDto
{
    public int Id { get; set; }
    [Required]
    public required string Name { get; set; }
    [Required]
    public required string Description { get; set; }
    [Required]
    public required string City { get; set; }
    [Required]
    public required string Address { get; set; }
    public AccessType AccessType { get; set; }
    [Required]
    public DateTime StartTime { get; set; }
    [Required]
    public DateTime EndTime { get; set; }
    [Required]
    public int? TicketsMax { get; set; }
    public int TicketsSold { get; set; }
    [Required]
    public bool HasSeat { get; set; }
    public required string ImagePath { get; set; } 
}

