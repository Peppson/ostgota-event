namespace Core.Services.Tickets;

public interface ITicketService
{
    Task<List<Ticket>> GetAllTickets();
    Task<TicketDTO> AddTicket(TicketDTO dto);
    Task<bool> RemoveTicket(int ticketId);
    List<TicketDTO> GetTicketDTO(List<Ticket> tickets);
    TicketDTO GetTicketDTO(Ticket ticket);
}
