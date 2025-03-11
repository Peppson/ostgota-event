/* namespace Core.Services;

// TODO: Implement better auth
/// <summary>
/// Simple auth service to enable registering and login in, should be replaced before release
/// </summary>
public class AuthService : IAuthService
{
    private readonly IDataService _dataService;

    public AuthService(IDataService database)
    {
        _dataService = database;
    }

    public User? Login(string username, string password)
    {
        var user = _dataService.Users.FirstOrDefault(u => u.Username == username);
        if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
        {
            return null;
        }

        return user;

    
    }

    public User? Register(string username, string password, string email, string? phonenumber)
    {
        if (_dataService.Users.Any(u => u.Username == username))
        {
            return null;
        }

        var user = new User(){ Username = username, PasswordHash = BCrypt.Net.BCrypt.HashPassword(password), Email = email, PhoneNumber = phonenumber }; 

        _dataService.Users.Add(user);
        return user;
    }
} 
 */
    /*public int Id { get; set; }
    public required string Username { get; set; }
    public required string PasswordHash { get; set; }
    public UserRoles Role { get; set; } = UserRoles.User;
    public required string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;*/