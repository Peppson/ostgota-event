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
        var user1 = new User
        {
            Username = "Dino",
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
            Address = "Kungsberget 3",
            TicketsMax = 2000,
            TicketsSold = 0,
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
            Address = "Prinskrönet 8",
            TicketsMax = 100,
            TicketsSold = 0,
            //HasSeat = false,                  // default
            ImagePath = "images/Food.jpg"
        };

        var sampleEvent3 = new Event
        {
            Name = "Waifu Convention",
            Description = "En härlig frodig plats där femboys och incels kan mingla uwu.",
            City = "Finspång",
            AccessType = AccessType.MemberOnly,
            StartTime = new DateTime(2025, 5, 20, 14, 0, 0, DateTimeKind.Local),
            EndTime = new DateTime(2025, 5, 22, 14, 0, 0, DateTimeKind.Local),
            Address = "Gatan 2",
            TicketsMax = 500,
            TicketsSold = 0,
            //HasSeat = false,                  // default
            ImagePath = "images/Talk.jpg"
        };
        var sampleEvent4 = new Event
        {
            Name = "Medeltidsvecka i Söderköping",
            Description = "Kom och sup in atmosfären av medeltiden i fantastiska Söderköping",
            City = "Söderköping",
            AccessType = AccessType.Free,
            StartTime = new DateTime(2025, 5, 20, 14, 0, 0, DateTimeKind.Local),
            EndTime = new DateTime(2025, 5, 23, 14, 0, 0, DateTimeKind.Local),
            Address = "Gatan 2",
            TicketsMax = null,
            TicketsSold = 0,
            //HasSeat = false,                  // default
            ImagePath = "images/Art.jpg"
        };
        var sampleEvent5 = new Event
        {
            Name = "Bondens Marknad",
            Description = "Upplev en härlig marknad med lokala råvaror direkt från gårdarna i Östergötland.",
            City = "Linköping",
            AccessType = AccessType.Free,
            StartTime = new DateTime(2025, 6, 1, 10, 0, 0, DateTimeKind.Local),
            EndTime = new DateTime(2025, 6, 1, 16, 0, 0, DateTimeKind.Local),
            Address = "Stora Torget",
            TicketsMax = null, 
            TicketsSold = 0,
            ImagePath = "images/Market.jpg"
        };

        var sampleEvent6 = new Event
        {
            Name = "Östgöta Raggae Fest",
            Description = "En skön sommarfestival med reggae, food trucks och avslappnad stämning vid Vätterns strand.",
            City = "Motala",
            AccessType = AccessType.Paid,
            StartTime = new DateTime(2025, 7, 5, 15, 0, 0, DateTimeKind.Local),
            EndTime = new DateTime(2025, 7, 6, 2, 0, 0, DateTimeKind.Local),
            Address = "Vätterstranden",
            TicketsMax = 3000,
            TicketsSold = 0,
            ImagePath = "images/Festival.jpg"
        };

        var sampleEvent7 = new Event
        {
            Name = "Gamla Linköpings Julmarknad",
            Description = "Upplev julstämningen i Gamla Linköping med hantverk, glögg och julmusik.",
            City = "Linköping",
            AccessType = AccessType.Free,
            StartTime = new DateTime(2025, 12, 10, 12, 0, 0, DateTimeKind.Local),
            EndTime = new DateTime(2025, 12, 10, 18, 0, 0, DateTimeKind.Local),
            Address = "Gamla Linköping",
            TicketsMax = null,
            TicketsSold = 0,
            ImagePath = "images/Run.jpg"
        };

        var sampleEvent8 = new Event
        {
            Name = "Löparfesten i Norrköping",
            Description = "Ett lopp för alla åldrar och nivåer – från barnlopp till halvmarathon genom Norrköping.",
            City = "Norrköping",
            AccessType = AccessType.Paid,
            StartTime = new DateTime(2025, 9, 14, 8, 0, 0, DateTimeKind.Local),
            EndTime = new DateTime(2025, 9, 14, 17, 0, 0, DateTimeKind.Local),
            Address = "Stadshuset",
            TicketsMax = 5000,
            TicketsSold = 0,
            ImagePath = "images/Spa.jpg"
        };

        var sampleEvent9 = new Event
        {
            Name = "Kulturfestival i Vadstena",
            Description = "Musik, konst och teater i hjärtat av den historiska staden Vadstena.",
            City = "Vadstena",
            AccessType = AccessType.MemberOnly,
            StartTime = new DateTime(2025, 8, 10, 14, 0, 0, DateTimeKind.Local),
            EndTime = new DateTime(2025, 8, 12, 22, 0, 0, DateTimeKind.Local),
            Address = "Vadstena Slott",
            TicketsMax = 800,
            TicketsSold = 0,
            ImagePath = "images/Whiskey.jpg"
        };

        var sampleEvent10 = new Event
        {
            Name = "Mopedrallyt i Kisa",
            Description = "Ett nostalgiskt mopedrally genom de vackra skogarna i södra Östergötland.",
            City = "Kisa",
            AccessType = AccessType.Paid,
            StartTime = new DateTime(2025, 6, 15, 9, 0, 0, DateTimeKind.Local),
            EndTime = new DateTime(2025, 6, 15, 15, 0, 0, DateTimeKind.Local),
            Address = "Torget i Kisa",
            TicketsMax = 100,
            TicketsSold = 0,
            ImagePath = "images/MantorpRacing.jpg"
        };


        await _db.Users.AddAsync(user);
        await _db.Users.AddAsync(user1);
        await _db.Users.AddAsync(admin);
        await _db.Events.AddAsync(sampleEvent1);
        await _db.Events.AddAsync(sampleEvent2);
        await _db.Events.AddAsync(sampleEvent3);
        await _db.Events.AddAsync(sampleEvent4);
        await _db.Events.AddAsync(sampleEvent5);
        await _db.Events.AddAsync(sampleEvent6);
        await _db.Events.AddAsync(sampleEvent7);
        await _db.Events.AddAsync(sampleEvent8);
        await _db.Events.AddAsync(sampleEvent9);
        await _db.Events.AddAsync(sampleEvent10);

        await _db.SaveChangesAsync();
        var secondUser = _db.Users.FirstOrDefault(u => u.Id == 2);
        var secondEvent = _db.Events.FirstOrDefault(e => e.Id == 2);
        var ticket = new Ticket
        {
            UserId = _db.Users.First().Id,
            User = _db.Users.First(),
            EventId = _db.Events.First().Id,
            Event = _db.Events.First(),
            Price = _db.Events.First().AccessType == AccessType.Paid ? 100 : 0,
            Seat = "A1",
        };

        var ticket1 = new Ticket
        {
            UserId = secondUser.Id,
            User = secondUser,
            EventId = _db.Events.First().Id,
            Event = _db.Events.First(),
            Price = _db.Events.First().AccessType == AccessType.Paid ? 100 : 0,
            Seat = "A2",  
        };

        var ticket2 = new Ticket
        {
            UserId = secondUser.Id,
            User = secondUser,
            EventId = _db.Events.First().Id,
            Event = _db.Events.First(),
            Price = _db.Events.First().AccessType == AccessType.Paid ? 100 : 0,
            Seat = "A3",  
        };

        var ticket3 = new Ticket
        {
            UserId = _db.Users.First().Id,
            User = _db.Users.First(),
            EventId = secondEvent.Id,
            Event = secondEvent,
            Price = secondEvent.AccessType == AccessType.Paid ? 150 : 0,
            Seat = "B1",
        };

        var ticket4 = new Ticket
        {
            UserId = _db.Users.First().Id,
            User = _db.Users.First(),
            EventId = secondEvent.Id,
            Event = secondEvent,
            Price = secondEvent.AccessType == AccessType.Paid ? 150 : 0,
            Seat = "B2",
        };

        user.BuyTicket(ticket);
        sampleEvent1.RegisterTicket();
        secondUser.BuyTicket(ticket1);
        sampleEvent1.RegisterTicket();
        secondUser.BuyTicket(ticket2);
        sampleEvent1.RegisterTicket();
        user.BuyTicket(ticket3);
        secondEvent.RegisterTicket();
        user.BuyTicket(ticket4);
        secondEvent.RegisterTicket();

        await _db.Tickets.AddAsync(ticket);
        await _db.Tickets.AddAsync(ticket1);
        await _db.Tickets.AddAsync(ticket2);
        await _db.Tickets.AddAsync(ticket3);
        await _db.Tickets.AddAsync(ticket4);
        await _db.SaveChangesAsync();
    }
}
