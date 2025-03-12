using Microsoft.Extensions.Logging;

namespace Core.Services;

public class DataService(Database DbContext) : IDataService
{
    private readonly Database _db = DbContext;

    public async Task<User?> GetUserByName(string username)
    {
        return await _db.Users.FirstOrDefaultAsync(u => u.Username == username);
    }

    public async Task<bool> DoesUserExist(string username)
    {
        return await _db.Users.AnyAsync(u => u.Username == username);
    }

    public async Task<List<User>> GetAllUsers()
    {
        return await _db.Users.ToListAsync();
    }

    public async Task AddUser(User user)
    {
        _db.Users.Add(user);
        await _db.SaveChangesAsync();
    }

    public async Task RemoveUser(User user)
    {
        _db.Users.Remove(user);
        await _db.SaveChangesAsync();
    }


    // EVENTS

    public async Task<Event?> GetEventById(int id)
    {
        return await _db.Events.FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<Event?> DoesEventExist(string name)
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

    public async Task<Event> RemoveEvent(int eventId)
    {
        var existingEvent = await _db.Events.FindAsync(eventId);
        if (existingEvent == null)
            throw new KeyNotFoundException("Event not found");

        _db.Events.Remove(existingEvent);
        await _db.SaveChangesAsync();
        return existingEvent;
    }

    // TICKETS

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
