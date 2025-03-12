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
    private int _ticketsSold = 0;
    public int TicketsSold => _ticketsSold;
    public int RemainingTickets => TicketsMax - _ticketsSold;

    public bool IsSoldOut => RemainingTickets == 0;

    public void RegisterTicket(int count)
    {
        if (count <= 0)
        {
            throw new ArgumentException("Antalet biljetter måste vara minst 1.");
        }
        if (count > RemainingTickets)
        {
            throw new InvalidOperationException("Inte tillräckligt många biljetter tillgängliga");
        }
        _ticketsSold += count;
    }



    public void CancelTicket(int count)
    {
        if (count <= 0)
        {
            throw new ArgumentException("Antalet biljetter måste vara minst 1.");
        }
        if (count > _ticketsSold)
        {
            throw new InvalidOperationException("Inte tillräckligt många biljetter att ta bort");
        }
        _ticketsSold -= count;
    }

}

public enum AccessType
{
    Free,
    Paid,
    MemberOnly
}
