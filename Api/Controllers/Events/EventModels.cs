namespace Api.Controllers.Events;

public record EventCreateDTO 
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string City { get; set; }
    public required string Address { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public AccessType AccessType { get; set; }
    public bool HasSeat { get; set; }
    public required string ImagePath { get; set; }
    public int? TicketsMax { get; set; }
};

public record EventUpdateDTO 
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string City { get; set; }
    public required string Address { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public AccessType AccessType { get; set; }
    public bool HasSeat { get; set; }
    public required string ImagePath { get; set; }
    public int? TicketsMax { get; set; }
    public int TicketsSold { get; set; }
};
