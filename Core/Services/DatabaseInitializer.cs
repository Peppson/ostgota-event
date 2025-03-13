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
        try // ¯\_(ツ)_/¯ 
        {
            _db.Database.EnsureDeleted(); 
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
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("password"),
            Email = "user@example.com",
            PhoneNumber = "123-456-7890",
            //Role = UserRoles.User,            // default
            //CreatedAt = DateTime.UtcNow,      // default
            //Tickets...                        // List<Tickets>
        };

        var admin = new User
        {
            Username = "admin",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("password"),
            Email = "admin@example.com",
            PhoneNumber = "123-456-7890",
            Role = UserRole.Admin,
            //CreatedAt = DateTime.UtcNow,      // default
            //Tickets...                        // List<Tickets>
        };

        var sampleEvent1 = new Event
        {
            Name = "Chad Event",
            Description = "Chad event description.",
            City = "Chad City",
            AccessType = AccessType.Free, 
            StartTime = DateTime.UtcNow,
            EndTime = DateTime.UtcNow.AddHours(3),
            Adress = "Kungsberget 3",
            TicketsMax = 100,
            //HasSeat = false,                  // default
            ImagePath = "images/Knight.jpg"     // nullable
        };

        var sampleEvent2 = new Event
        {
            Name = "Dino Event",
            Description = "Dino event description.",
            City = "Dino City",
            AccessType = AccessType.MemberOnly, 
            StartTime = DateTime.UtcNow,
            EndTime = DateTime.UtcNow.AddHours(3),
            Adress = "Prinskrönet 8",
            TicketsMax = 100,
            //HasSeat = false,                  // default
            ImagePath = "https://ih1.redbubble.net/image.1833920974.3208/flat,750x,075,f-pad,750x1000,f8f8f8.jpg"
        };

        await _db.Users.AddAsync(user);
        await _db.Users.AddAsync(admin);
        await _db.Events.AddAsync(sampleEvent1);
        await _db.Events.AddAsync(sampleEvent2);
        await _db.SaveChangesAsync();

        var ticket = new Ticket
        {
            UserId = _db.Users.First().Id,
            User = _db.Users.First(),
            EventId = _db.Events.First().Id,
            Event = _db.Events.First(),
            Price = 0,
            //Seat = "A1",                      // nullable
        };

        await _db.Tickets.AddAsync(ticket);
        await _db.SaveChangesAsync();
    }
}
