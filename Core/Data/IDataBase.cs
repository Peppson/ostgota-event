namespace Core.Data;

public interface IDatabase
{   
    DbSet<User> Users { get; set; }
    DbSet<Event> Events { get; set; }
    DbSet<Ticket> Tickets { get; set; }
    Task<int> SaveChangesAsync();
}
