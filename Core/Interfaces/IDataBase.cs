namespace Core.Interfaces;

public interface IDatabase
{
    List<Event> Events { get; set; }
    List<User> Users { get; set; }
    List<Ticket> Tickets { get; set; }
}
