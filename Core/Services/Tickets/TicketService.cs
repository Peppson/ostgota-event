namespace Core.Services.Tickets;

public class TicketDTO
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int EventId { get; set; }
    public decimal Price { get; set; }
    public string? Seat { get; set; } 
}

public class TicketService(Database DbContext) : ITicketService
{
    private readonly Database _db = DbContext;


    public async Task<List<TicketDTO>> GetAllTickets()
    {   
        var tickets = await _db.Tickets.ToListAsync();
        return GetTicketDTO(tickets);
    }

    public async Task<TicketDTO> AddTicket(TicketDTO dto)
    {   
        var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == dto.UserId);
        var event1 = await _db.Events.FirstOrDefaultAsync(e => e.Id == dto.EventId);

        if (user == null || event1 == null) return null!;

        if (event1.IsSoldOut)
            throw new InvalidOperationException("Cannot purchase ticket. The event is sold out.");


        var newTicket = new Ticket() 
        {
            UserId = dto.UserId,
            User = user,
            EventId = dto.EventId,
            Event = event1,
            Price = dto.Price,
            Seat = dto.Seat
        };

        user.BuyTicket(newTicket);
        event1.RegisterTicket();
        await _db.SaveChangesAsync();

        return dto;
    }

    public async Task<bool> RemoveTicket(int ticketId)
    {   
        var ticket = await _db.Tickets
            .Include(t => t.User)
            .Include(t => t.Event)
            .FirstOrDefaultAsync(t => t.Id == ticketId);

        if (ticket == null) 
            return false;

        var user = ticket.User;
        var event1 = ticket.Event;

        user.CancelTicket(ticket);
        event1.CancelTicket();
        await _db.SaveChangesAsync();

        return true;
    }

    public List<TicketDTO> GetTicketDTO(List<Ticket> tickets)
    {
        return tickets.Select(t => new TicketDTO
        {
            Id = t.Id,
            UserId = t.UserId,
            EventId = t.EventId,
            Price = t.Price,
            Seat = t.Seat
        }).ToList();
    }

    public TicketDTO GetTicketDTO(Ticket ticket)
    {
        return new TicketDTO
        {
            Id = ticket.Id,
            UserId = ticket.UserId,
            EventId = ticket.EventId,
            Price = ticket.Price,
            Seat = ticket.Seat
        };
    }
}
