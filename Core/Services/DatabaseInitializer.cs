namespace Core.Services;

public class DatabaseInitializer
{
    private readonly Database _db;

    public DatabaseInitializer(Database db)
    {
        _db = db;
    }

    public void InitDatabase()
    {
        // Check if the database was created if so seed it
        if (_db.Database.EnsureCreated())
        {
            SeedDatabase();
        }
    }

    public void ResetDatabase()
    {
        try
        {
            // ¯\_(ツ)_/¯ 
            _db.Database.EnsureDeleted();
            _db.Database.EnsureCreated();
            SeedDatabase();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while resetting database: {ex.Message}");
        }
    }

    private void SeedDatabase()
    {
        var user = new User
        {
            Username = "user",
            PasswordHash = "password",
            Email = "user@example.com",
            PhoneNumber = "123-456-7890",
            //Role = UserRoles.User,            // default
            //CreatedAt = DateTime.UtcNow,      // default
            // Tickets...
        };
        _db.Users.Add(user);
        _db.SaveChanges();
        
        var sampleEvent = new Event
        {
            Name = "Sample Event",
            Description = "Sample event description.",
            City = "Chad City",
            AccessType = AccessType.Free, 
            StartTime = DateTime.UtcNow,
            EndTime = DateTime.UtcNow.AddHours(3),
            TicketsSold = 0,
            TicketsMax = 100,
            //HasSeat = false,                  // default
            //ImagePath = ""                    // nullable
        };
        _db.Events.Add(sampleEvent);
        _db.SaveChanges();

        var ticket = new Ticket
        {
            UserId = _db.Users.First().Id,
            User = _db.Users.First(),
            EventId = _db.Events.First().Id,
            Event = _db.Events.First(),
            Price = 29.99m,
            //Seat = "A1",                      // nullable
        };
        _db.Tickets.Add(ticket);
        _db.SaveChanges();
    }
}
