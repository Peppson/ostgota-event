namespace Core.Services;

public class DatabaseInitializer(Database db)
{
    private readonly Database _db = db;

    public async Task InitDatabase()
    {
        // Check if new database was created if so seed it
        if (_db.Database.EnsureCreated())
        {
            await SeedDatabase();
        }
    }

    public async Task ResetDatabase()
    {
        try
        {
            _db.Database.EnsureDeleted(); // ¯\_(ツ)_/¯ 
            _db.Database.EnsureCreated();
            await SeedDatabase();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while resetting database: {ex.Message}");
        }
    }

    private async Task SeedDatabase()
    {
        var user = new User
        {
            Username = "user",
            PasswordHash = "password",          // Todo add hashing
            Email = "user@example.com",
            PhoneNumber = "123-456-7890",
            //Role = UserRoles.User,            // default
            //CreatedAt = DateTime.UtcNow,      // default
            //Tickets...                        // List<Tickets>
        };

        var admin = new User
        {
            Username = "admin",
            PasswordHash = "password",          // Todo add hashing
            Email = "admin@example.com",
            PhoneNumber = "123-456-7890",
            Role = UserRoles.Admin,
            //CreatedAt = DateTime.UtcNow,      // default
            //Tickets...                        // List<Tickets>
        };

        var sampleEvent = new Event
        {
            Name = "Chad Event",
            Description = "Chad event description.",
            City = "Chad City",
            AccessType = AccessType.Free, 
            StartTime = DateTime.UtcNow,
            EndTime = DateTime.UtcNow.AddHours(3),
            TicketsSold = 0,
            TicketsMax = 100,
            //HasSeat = false,                  // default
            //ImagePath = ""                    // nullable
        };

        await _db.Users.AddAsync(user);
        await _db.Users.AddAsync(admin);
        await _db.Events.AddAsync(sampleEvent);
        await _db.SaveChangesAsync();

        var ticket = new Ticket
        {
            UserId = _db.Users.First().Id,
            User = _db.Users.First(),
            EventId = _db.Events.First().Id,
            Event = _db.Events.First(),
            Price = 29.99m,
            //Seat = "A1",                      // nullable
        };

        await _db.Tickets.AddAsync(ticket);
        await _db.SaveChangesAsync();
    }
}
