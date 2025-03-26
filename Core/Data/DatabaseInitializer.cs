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
            Username = "arif",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("password"),
            Email = "arif@bil.com",
            PhoneNumber = "123-456-7890",
            Role = UserRole.User,
        };

        var admin = new User
        {
            Username = "admin",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("password"),
            Email = "admin@admin.com",
            PhoneNumber = "123-456-7890",
            Role = UserRole.Admin,
        };

        var sampleEvent1 = new Event
        {
            Name = "Söderköpings Gästabud",
            Description = "Söderköpings Gästabud är en årlig medeltidsfestival där stadens gator fylls med marknadsstånd, gycklare, riddartorneringar och historiska uppträdanden. Besökare kan uppleva autentiska hantverk, smaka på historisk mat och lyssna på medeltida musik. Evenemanget återskapar stadens rika historia som en viktig handels- och mötesplats under medeltiden. Festivalen lockar både lokalbor och turister som vill uppleva en levande tidsresa tillbaka till medeltidens Sverige.",
            City = "Söderköping",
            AccessType = AccessType.Free,
            StartTime = DateTime.SpecifyKind(new DateTime(2025, 4, 10, 18, 0, 0), DateTimeKind.Utc),
            EndTime = DateTime.SpecifyKind(new DateTime(2025, 4, 17, 23, 0, 0), DateTimeKind.Utc),
            Address = "Kyrkparken",
            TicketsMax = null,
            TicketsSold = 0,
            HasSeat = false,
            ImagePath = "images/Knight.jpg",
            Price = 0
        };

        var sampleEvent2 = new Event
        {
            Name = "Restaurang Jord",
            Description = "Restaurang Jord i Linköping har tilldelats en grön stjärna i Guide Michelin för sitt starka engagemang för hållbarhet. Deras filosofi \"från skog till tallrik\" innebär att de använder vilda och hyper-säsongsbetonade ingredienser, inklusive egenplockade örter, frukter och bär, samt viltkött jagat av ägaren Andreas Landén. Restaurangen erbjuder en överraskningsavsmakningsmeny med kreativa rätter som kombinerar olika smaker och texturer. Dessutom är Jord en miljösäkrad verksamhet som använder en ekologisk träbyggnad, återvinner regnvatten och drivs av solenergi.",
            City = "Linköping",
            AccessType = AccessType.Free,
            StartTime = DateTime.SpecifyKind(new DateTime(2025, 5, 14, 18, 0, 0), DateTimeKind.Utc),
            EndTime = DateTime.SpecifyKind(new DateTime(2025, 5, 14, 23, 30, 0), DateTimeKind.Utc),
            Address = "Johannesborgsparken 1A",
            TicketsMax = 100,
            TicketsSold = 20,
            HasSeat = true,
            ImagePath = "images/Food.jpg",
            Price = 0
        };

        var sampleEvent3 = new Event
        {
            Name = "NärCon",
            Description = "NärCon är ett helt unikt event. Det är en alkohol- och drogfri festival där du skaffar nya vänner, cosplayar och spelar spel tillsammans. Det finns över 900 aktiviteter, från föreläsningar och scenshower till lekar och turneringar, men det är den sociala atmosfären som NärCon verkligen handlar om; det är en mötesplats för alla med nördiga intressen.",
            City = "Linköping",
            AccessType = AccessType.Paid,
            StartTime = DateTime.SpecifyKind(new DateTime(2025, 5, 12, 12, 0, 0), DateTimeKind.Utc),
            EndTime = DateTime.SpecifyKind(new DateTime(2025, 5, 19, 18, 0, 0), DateTimeKind.Utc),
            Address = "Linköpings Universitet",
            TicketsMax = 500,
            TicketsSold = 499,
            HasSeat = true,
            ImagePath = "images/Talk.jpg",
            Price = 299
        };

        var sampleEvent4 = new Event
        {
            Name = "Kuldag på Norrköpings Konstmuseum",
            Description = "Välkommen till Barnens Konstdag på Norrköpings Konstmuseum! En dag fylld med skaparglädje, lek och upptäckter för alla små konstnärer. Prova spännande workshops, måla egna mästerverk, delta i sagostunder och utforska museets färgsprakande värld. Våra pedagoger guidar barnen genom kreativa aktiviteter som inspirerar fantasin. Perfekt för hela familjen – kom och upplev en dag där konsten får liv genom lek och lärande!",
            City = "Norrköping",
            AccessType = AccessType.Paid,
            StartTime = DateTime.SpecifyKind(new DateTime(2025, 5, 23, 12, 0, 0), DateTimeKind.Utc),
            EndTime = DateTime.SpecifyKind(new DateTime(2025, 5, 23, 20, 0, 0), DateTimeKind.Utc),
            Address = " Kristinagatan",
            TicketsMax = 200,
            TicketsSold = 79,
            ImagePath = "images/Art.jpg",
            Price = 199
        };

        var sampleEvent5 = new Event
        {
            Name = "Tjällmo Marknad",
            Description = "Tjällmo Marknad, eller Tjällmo Marken om man så vill, är en populär tillställning som samlar besökare från när och fjärran att ta del av bland annat marknadsknallar, underhållning och bilutställning.",
            City = "Tjällmo",
            AccessType = AccessType.Free,
            StartTime = DateTime.SpecifyKind(new DateTime(2025, 5, 28, 9, 0, 0), DateTimeKind.Utc),
            EndTime = DateTime.SpecifyKind(new DateTime(2025, 5, 29, 23, 0, 0), DateTimeKind.Utc),
            Address = "Tjällmo",
            TicketsMax = null,
            TicketsSold = 0,
            ImagePath = "images/Market.jpg",
            Price = 0
        };

        var sampleEvent6 = new Event
        {
            Name = "Skogsröjet",
            Description = "Rockfestivalen där skogen vibrerar av hårdrock och gemenskap! Varje år samlas rock- och metalfans i Rejmyre för en oförglömlig helg fylld med legendariska band, nya upptäckter och en unik atmosfär. Upplev intensiva livespelningar, träffa likasinnade och njut av den familjära festivalstämningen. Med två scener, camping och ett ständigt pumpande röj är detta sommarens höjdpunkt för alla rockälskare. Missa inte chansen att headbanga under talltopparna!",
            City = "Rejmyre",
            AccessType = AccessType.Paid,
            StartTime = DateTime.SpecifyKind(new DateTime(2025, 6, 1, 7, 0, 0), DateTimeKind.Utc),
            EndTime = DateTime.SpecifyKind(new DateTime(2025, 6, 4, 22, 0, 0), DateTimeKind.Utc),
            Address = "Mästarevägen 31C",
            TicketsMax = 3200,
            TicketsSold = 0,
            ImagePath = "images/Festival.jpg",
            Price = 1120
        };

        var sampleEvent7 = new Event
        {
            Name = "Mjölby varvet",
            Description = "Välkommen till Mjölby Varvet – en energifylld löparfest för alla! Oavsett om du är en erfaren löpare eller nybörjare, erbjuder Mjölby Varvet en utmaning för alla nivåer. Tävla på den natursköna banan, känn peppen längs vägen och upplev den härliga gemenskapen i en av Mjölbys största sportevenemang. Med musik, publikhejar och en festlig stämning är det mer än bara ett lopp – det är en riktigt sportig folkfest! Bli en del av Mjölbys löpartradition och spring för hälsan, för gemenskapen, och för glädjen!",
            City = "Mjölby",
            AccessType = AccessType.Free,
            StartTime = DateTime.SpecifyKind(new DateTime(2025, 6, 12, 12, 0, 0), DateTimeKind.Utc),
            EndTime = DateTime.SpecifyKind(new DateTime(2025, 6, 12, 18, 0, 0), DateTimeKind.Utc),
            Address = "Mjölby",
            TicketsMax = null,
            TicketsSold = 0,
            ImagePath = "images/Run.jpg",
            Price = 0
        };

        var sampleEvent8 = new Event
        {
            Name = "Spa & Relax - Vadstena Kloster",
            Description = "Här bjuds du in till ditt inre rum, och får ta del av en unik sparetreat på dina villkor. Unna dig en paus i vår vackra miljö skapad för att balansera både kropp & själ- med en historisk inramning och förankring i vårt medeltida arv. Sänk axlarna och andas ut under en inledande badceremoni i Klosterbadet, för att sedan hämta ny kraft i Wellnessavdelningen inrett med ljusets läkande egenskaper som tema. Ta en paus i det vackra orangeriet med något gott att äta och dricka- för att avsluta med en stunds vila & meditation i våra vilrum.",
            City = "Vadstena",
            AccessType = AccessType.Paid,
            StartTime = DateTime.SpecifyKind(new DateTime(2025, 6, 23, 7, 0, 0), DateTimeKind.Utc),
            EndTime = DateTime.SpecifyKind(new DateTime(2025, 6, 24, 18, 0, 0), DateTimeKind.Utc),
            Address = "Lasarettsgatan 3",
            TicketsMax = 30,
            TicketsSold = 0,
            ImagePath = "images/Spa.jpg",
            Price = 1499
        };

        var sampleEvent9 = new Event
        {
            Name = "Whiskeyprovning - The Horse and Hound",
            Description = "Upplev en exklusiv whiskyprovning på The Horse and Hound i Linköping! Njut av en smakresa genom noggrant utvalda whiskysorter, där våra experter guidar dig genom dofter, smaker och historier bakom varje droppe. Oavsett om du är nybörjare eller whiskyentusiast får du en upplevelse fylld av kunskap och njutning i en genuin pubmiljö. Ta med vännerna och låt er inspireras av hantverket bakom denna ädla dryck. Boka din plats och upptäck whisky på ett helt nytt sätt!",
            City = "Linköping",
            AccessType = AccessType.Paid,
            StartTime = DateTime.SpecifyKind(new DateTime(2025, 4, 13, 18, 0, 0), DateTimeKind.Utc),
            EndTime = DateTime.SpecifyKind(new DateTime(2025, 4, 13, 23, 0, 0), DateTimeKind.Utc),
            Address = "Storgatan 39",
            TicketsMax = 100,
            TicketsSold = 53,
            ImagePath = "images/Whiskey.jpg",
            Price = 399
        };

        var sampleEvent10 = new Event
        {
            Name = "Polustus karnevaltåg",
            Description = "Polustus är en älskad karnevalstradition i Grytgöl som har funnits i över 70 år! Varje midsommarafton samlas bybor och besökare för ett humoristiskt och festligt tågtåg som driver med lokala och globala händelser från det gångna året. Med skojiga inslag och en lekfull ton har Polustus blivit en årlig höjdpunkt för både unga och gamla. På vår sida hittar du bilder, historia och allt du behöver veta om detta unika karnevalståg. Välkommen att ta del av traditionen och skriv gärna en rad i vår gästbok!",
            City = "Grytgöl",
            AccessType = AccessType.Free,
            StartTime = DateTime.SpecifyKind(new DateTime(2025, 6, 21, 10, 0, 0), DateTimeKind.Utc),
            EndTime = DateTime.SpecifyKind(new DateTime(2025, 6, 21, 21, 0, 0), DateTimeKind.Utc),
            Address = "Grytgöl",
            TicketsMax = null,
            TicketsSold = 0,
            ImagePath = "images/Grytgöl.jpg",
            Price = 0
        };


        await _db.Users.AddAsync(user);
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

        var firstUser = _db.Users.FirstOrDefault(u => u.Id == 1);
        var secondEvent = _db.Events.FirstOrDefault(e => e.Id == 2);

        var ticket0 = new Ticket
        {
            UserId = _db.Users.First().Id,
            User = _db.Users.First(),
            EventId = sampleEvent6.Id,
            Event = sampleEvent6,
            Price = sampleEvent6.Price,
            Seat = null,
        };

        var ticket1 = new Ticket
        {
            UserId = _db.Users.First().Id,
            User = _db.Users.First(),
            EventId = sampleEvent6.Id,
            Event = sampleEvent6,
            Price = sampleEvent6.Price,
            Seat = null,
        };

        var ticket2 = new Ticket
        {
            UserId = _db.Users.First().Id,
            User = _db.Users.First(),
            EventId = sampleEvent3.Id,
            Event = sampleEvent3,
            Price = sampleEvent3.Price,
            Seat = null,
        };

        var ticket3 = new Ticket
        {
            UserId = _db.Users.First().Id,
            User = _db.Users.First(),
            EventId = sampleEvent9.Id,
            Event = sampleEvent9,
            Price = sampleEvent9.Price,
            Seat = "A1",
        };

        user.BuyTicket(ticket0);
        sampleEvent6.RegisterTicket();

        user.BuyTicket(ticket1);
        sampleEvent6.RegisterTicket();

        user.BuyTicket(ticket2);
        sampleEvent3.RegisterTicket();

        user.BuyTicket(ticket3);
        sampleEvent9.RegisterTicket();

        await _db.Tickets.AddAsync(ticket0);
        await _db.Tickets.AddAsync(ticket1);
        await _db.Tickets.AddAsync(ticket2);
        await _db.Tickets.AddAsync(ticket3);

        await _db.SaveChangesAsync();
    }
}
