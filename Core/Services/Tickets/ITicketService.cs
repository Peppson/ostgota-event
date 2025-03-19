namespace Core.Services.Tickets;

public interface ITicketService
{
    Task<List<Ticket>> GetAllTickets();
    Task<Ticket?> AddTicket(int userId, int EventId, string? seat);
    Task<bool> RemoveTicket(int ticketId);
}
