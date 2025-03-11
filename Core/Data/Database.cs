namespace Core.Data;

public class Database : DbContext
{   
    public Database(DbContextOptions<Database> options) : base(options) {}

    public DbSet<User> Users { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
}
