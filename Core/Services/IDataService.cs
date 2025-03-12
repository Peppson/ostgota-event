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
    Task<Event?> GetEventByName(string name);
    Task<List<Event>> GetAllEvents();
    Task<Event> AddEvent(Event ev);
    Task<Event?> RemoveEvent(int eventId);
    Task<Event?> UpdateEvent(int eventId, Event updatedEvent);

    // Ticket
    Task<List<Ticket>> GetAllTickets();
    Task AddTicket(Ticket ticket);
    Task RemoveTicket(Ticket ticket);
}
