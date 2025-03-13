namespace Core.Services.Events;

public interface IEventService
{
    Task<Event?> GetEventById(int id);
    Task<Event?> GetEventByName(string name);
    Task<List<Event>> GetAllEvents();
    Task<Event> AddEvent(Event ev);
    Task<Event?> RemoveEvent(int eventId);
    Task<Event?> UpdateEvent(int eventId, Event updatedEvent);
}
