namespace Core.Services.Events;

public class EventService(Database DbContext) : IEventService
{
    private readonly Database _db = DbContext;


    public async Task<Event?> GetEventById(int id)
    {
        return await _db.Events.FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<Event?> GetEventByName(string name)
    {
        return await _db.Events.FirstOrDefaultAsync(u => u.Name == name);
    }

    public async Task<List<Event>> GetAllEvents()
    {
        return await _db.Events.ToListAsync();
    }

    public async Task<Event> AddEvent(Event ev)
    {
        _db.Events.Add(ev);
        await _db.SaveChangesAsync();
        return ev;
    }

    public async Task<Event?> RemoveEvent(int eventId)
    {
        var existingEvent = await _db.Events.FindAsync(eventId);
        if (existingEvent == null)
            return null;

        _db.Events.Remove(existingEvent);
        await _db.SaveChangesAsync();
        return existingEvent;
    }

    public async Task<Event?> UpdateEvent(int eventId, Event updatedEvent)
    {
        var existingEvent = await _db.Events.FindAsync(eventId);
        if (existingEvent == null)
            return null;

        existingEvent.Name = updatedEvent.Name;
        existingEvent.Description = updatedEvent.Description;
        existingEvent.City = updatedEvent.City;
        existingEvent.Address = updatedEvent.Address;
        existingEvent.AccessType = updatedEvent.AccessType;
        existingEvent.StartTime = updatedEvent.StartTime;
        existingEvent.EndTime = updatedEvent.EndTime;
        existingEvent.HasSeat = updatedEvent.HasSeat;
        existingEvent.ImagePath = updatedEvent.ImagePath;
        existingEvent.TicketsMax = updatedEvent.TicketsMax;
        existingEvent.TicketsSold = updatedEvent.TicketsSold;

        await _db.SaveChangesAsync();

        return existingEvent;
    }
}
