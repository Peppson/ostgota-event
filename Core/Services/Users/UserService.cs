namespace Core.Services.Users;

public class UserDTO
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public UserRole Role { get; set; }
    public List<TicketDTO> Tickets { get; set; } = []; 
}

public class UserService(Database DbContext) : IUserService
{
    private readonly Database _db = DbContext;


    public async Task<List<User>> GetAllUsers()
    {
        return await _db.Users.ToListAsync();
    }

    public async Task<bool> DoesUserExist(string username)
    {
        return await _db.Users.AnyAsync(u => u.Username == username);
    }

    public async Task<User?> GetUserByName(string username)
    {
        return await _db.Users.FirstOrDefaultAsync(u => u.Username == username);
    }

    public async Task<User?> GetUserById(int userId)
    {
        return await _db.Users.FirstOrDefaultAsync(u => u.Id == userId);
    }

    public async Task<UserDTO?> GetUserDTOByName(string username)
    {   
        var user = await _db.Users
            .Include(u => u.Tickets)
            .FirstOrDefaultAsync(u => u.Username == username);

        if (user == null)
            return null;

        return new UserDTO
        {
            Username = user.Username,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            Role = user.Role,
            Tickets = user.Tickets.Select(t => GetTicketDTO(t)).ToList()
        };
    }

    public async Task<UserDTO?> GetUserDTOById(int userId)
    {
        var user = await _db.Users
            .Include(u => u.Tickets)
            .FirstOrDefaultAsync(u => u.Id == userId);

        if (user == null)
            return null;

        return new UserDTO
        {
            Username = user.Username,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            Role = user.Role,
            Tickets = user.Tickets.Select(t => GetTicketDTO(t)).ToList()
        };
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

    public TicketDTO GetTicketDTO(Ticket ticket)
    {
        return new TicketDTO
        {
            Id = ticket.Id,
            UserId = ticket.UserId,
            EventId = ticket.EventId,
            Price = ticket.Price,
            Seat = ticket.Seat
        };
    }
}
