namespace Core.Services.Tickets;

public interface ITicketService
{
    Task<List<Ticket>> GetAllTickets();
    Task AddTicket(Ticket ticket);
    Task RemoveTicket(Ticket ticket);
}
