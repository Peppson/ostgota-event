namespace Core.Services.Users;

public class UserService(Database DbContext) : IUserService
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
}
