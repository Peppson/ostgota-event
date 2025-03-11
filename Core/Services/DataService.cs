namespace Core.Data;

public class DataService
{
    private readonly AppDbContext _context;

    public DataService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<List<Event>> GetAllEvents()
    {
        return await _context.Events.ToListAsync();
    }

    public async Task AddEvent(Event ev)
    {
        _context.Events.Add(ev);
        await _context.SaveChangesAsync();
    }
}



// repository pattern DB
// Mocka  
// init default values
