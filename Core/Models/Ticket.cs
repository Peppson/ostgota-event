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
    public string? Seat { get; set; }
    public string Title => Event.Name;
    [Required]
    public decimal Price
    {
        get
        {
            return _price;
        }
        set
        {
            if (Event.AccessType == AccessType.Free)
                _price = 0;
            else
                _price = value;
        }
    }
    private decimal _price;
}
