namespace Core.Services;

public interface IDataService
{
    Task<User?> GetUserByName(string username);
    Task<bool> DoesUserExist(string username);
    Task<List<User>> GetAllUsers();
    Task AddUser(User user);
    Task<List<Event>> GetAllEvents();
    Task AddEvent(Event ev);
    Task<List<Ticket>> GetAllTickets();
    Task AddTicket(Ticket ticket);
}
