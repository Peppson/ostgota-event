namespace Core.Data;

public class DataService
{
    private readonly Database _db;

    public DataService(Database DbContext) // Todo add interface
    {
        _db = DbContext;
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        return await _db.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<List<Event>> GetAllEvents()
    {
        return await _db.Events.ToListAsync();
    }

    public async Task AddEvent(Event ev)
    {
        _db.Events.Add(ev);
        await _db.SaveChangesAsync();
    }
}
