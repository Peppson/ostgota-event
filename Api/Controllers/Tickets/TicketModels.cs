namespace Api.Controllers.Tickets;

public record TicketDTO
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int EventId { get; set; }
    public string? Seat { get; set; } 
    public decimal Price { get; set; }
}

public record TicketCreateDTO
{
    public int UserId { get; set; }
    public int EventId { get; set; }
    public string? Seat { get; set; } 
    public decimal Price { get; set; }
}
