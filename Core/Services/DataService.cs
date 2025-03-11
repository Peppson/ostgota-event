namespace Core.Data;

public class DataService
{
    private readonly Database _Db;

    public DataService(Database DbContext) // Todo add interface
    {
        _Db = DbContext;
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        return await _Db.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<List<Event>> GetAllEvents()
    {
        return await _Db.Events.ToListAsync();
    }

    public async Task AddEvent(Event ev)
    {
        _Db.Events.Add(ev);
        await _Db.SaveChangesAsync();
    }
}
