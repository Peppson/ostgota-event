namespace Data;

public class Database : IDatabase
{
    public List<Event> Events { get; set; } = [];
    public List<User> Users { get; set; } = [];
    public List<Ticket> Tickets { get; set; } = [];
}
