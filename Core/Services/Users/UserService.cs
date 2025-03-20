namespace Core.Services.Users;

public class UserService(IDatabase DbContext) : IUserService
{
    private readonly IDatabase _db = DbContext;


    public async Task<List<User>> GetAllUsers()
    {
        var users = await _db.Users
            .Include(t => t.Tickets)
            .ThenInclude(e => e.Event)
            .ToListAsync();

        return users;
    }

    public async Task<bool> DoesUserExist(string username)
    {
        return await _db.Users.AnyAsync(u => u.Username == username);
    }

    public async Task<User?> GetUserByName(string username)
    {
        var user = await _db.Users
            .Include(u => u.Tickets)
            .ThenInclude(e => e.Event)
            .FirstOrDefaultAsync(u => u.Username == username);

        if (user == null)
            return null;

        return user;
    }

    public async Task<User?> GetUserById(int userId)
    {
        var user = await _db.Users
            .Include(u => u.Tickets)
            .ThenInclude(e => e.Event)
            .FirstOrDefaultAsync(u => u.Id == userId);

        if (user == null)
            return null;

        return user;
    }

    public async Task AddUser(User user)
    {
        _db.Users.Add(user);
        await _db.SaveChangesAsync();
    }

    public async Task<bool> RemoveUserById(int userId)
    {
        var user = await _db.Users
            .Include(u => u.Tickets)
            .ThenInclude(t => t.Event)
            .FirstOrDefaultAsync(u => u.Id == userId);

        if (user == null) return false;

        if (user.Tickets.Count > 0)
        {
            foreach (var ticket in user.Tickets)
            {
                ticket.Event.CancelTicket();
            }
        }

        _db.Users.Remove(user);
        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<User?> UpdateUserAdmin(int userId, User updatedUser)
    {
        var existingUser = await _db.Users.FindAsync(userId);
        if (existingUser == null)
            return null;

        existingUser.Username = updatedUser.Username;
        existingUser.Email = updatedUser.Email;
        existingUser.PhoneNumber = updatedUser.PhoneNumber;
        existingUser.Role = updatedUser.Role;

        await _db.SaveChangesAsync();

        return existingUser;
    }

    public async Task<User?> UpdateUser(int userId, User updatedUser)
    {
        var existingUser = await _db.Users.FindAsync(userId);
        if (existingUser == null)
            return null;

        existingUser.PasswordHash = updatedUser.PasswordHash;
        existingUser.Email = updatedUser.Email;
        existingUser.PhoneNumber = updatedUser.PhoneNumber;

        await _db.SaveChangesAsync();

        return existingUser;
    }
}
