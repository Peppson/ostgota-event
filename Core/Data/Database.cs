using Microsoft.EntityFrameworkCore;

namespace Core.Data;


/* namespace BlazingPizza.Data;

public class PizzaStoreContext : DbContext
{
    public PizzaStoreContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<PizzaSpecial> Specials { get; set; }
} */



public class Database : IDatabase   //, DbContext
{
    public List<Event> Events { get; set; } = [];
    public List<User> Users { get; set; } = [];
    public List<Ticket> Tickets { get; set; } = [];
}
