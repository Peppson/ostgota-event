namespace Core.Services.Tickets;

public class TicketService(IDatabase DbContext) : ITicketService
{
    private readonly IDatabase _db = DbContext;


    public async Task<List<Ticket>> GetAllTickets()
    {   
        return await _db.Tickets
            .Include(e => e.Event)
            .ToListAsync();
    }

    public async Task<Ticket?> AddTicket(int userId, int eventId, decimal price, string? seat)
    {   
        var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == userId);
        var foundEvent = await _db.Events.FirstOrDefaultAsync(e => e.Id == eventId);

        if (user == null)
            throw new InvalidOperationException("User not found.");
        
        if (foundEvent == null)
            throw new InvalidOperationException("Event not found.");

        if (foundEvent.IsSoldOut)
            throw new InvalidOperationException("Cannot purchase ticket. The event is sold out.");

        var newTicket = new Ticket()
        {
            UserId = userId,
            User = user,
            EventId = eventId,
            Event = foundEvent,
            Seat = seat,
            Price = (foundEvent.AccessType == AccessType.Free) ? 0 : price
        };

        user.BuyTicket(newTicket);
        foundEvent.RegisterTicket();
        await _db.SaveChangesAsync();

        return newTicket;
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
}
