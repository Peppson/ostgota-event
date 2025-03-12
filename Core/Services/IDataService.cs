namespace Core.Services;

public interface IDataService
{
    // User
    Task<User?> GetUserByName(string username);
    Task<bool> DoesUserExist(string username);
    Task<List<User>> GetAllUsers();
    Task AddUser(User user);
    Task RemoveUser(User user);

    // Event
    Task<Event?> GetEventById(int id);
    Task<Event?> DoesEventExist(string name);
    Task<List<Event>> GetAllEvents();

    // Ticket
    Task<List<Ticket>> GetAllTickets();
    Task AddTicket(Ticket ticket);
    Task RemoveTicket(Ticket ticket);
}
