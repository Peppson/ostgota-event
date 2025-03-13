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

    private decimal _price;

    [Required]
    public decimal Price
    {
        get
        {
            return Event.AccessType == AccessType.Free ? 0 : _price;
        }
        set
        {
            if (Event.AccessType == AccessType.Free && value > 0)
            {
                throw new InvalidOperationException("Gratisbiljetter kan inte ha ett pris.");
            }
            _price = value;
        }
    }

}
