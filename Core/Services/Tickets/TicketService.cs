namespace Core.Services.Tickets;

public class TicketService(Database DbContext) : ITicketService
{
    private readonly Database _db = DbContext;

    public async Task<List<Ticket>> GetAllTickets()
    {
        return await _db.Tickets.ToListAsync();
    }

    public async Task AddTicket(Ticket ticket)
    {
        _db.Tickets.Add(ticket);
        await _db.SaveChangesAsync();
    }

    public async Task RemoveTicket(Ticket ticket)
    {
        _db.Tickets.Remove(ticket);
        await _db.SaveChangesAsync();
    }
}
