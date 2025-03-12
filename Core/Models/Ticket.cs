namespace Core.Models;

public class Ticket
{   
    [Key]
    public int Id { get; set; }
    [Required]
    public int UserId { get; set; }
    public required User User { get; set; }
    [Required]
    public int EventId { get; set; }
    public required Event Event { get; set; }
    [Required]
    public decimal Price { get; set; }
    public string? Seat { get; set; } 
    public string Title => Event.Name;
}
