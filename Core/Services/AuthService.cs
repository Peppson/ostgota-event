
namespace Core.Services;

// TODO: Implement better auth
/// <summary>
/// Simple auth service to enable registering and login in, should be replaced before release
/// </summary>
public class AuthService : IAuthService
{
    private readonly IDataService _dataService;

    public AuthService(IDataService dataService)
    {
        _dataService = dataService;
    }
 
    public async Task<User?> Login(string username, string password)
    {
        var user = await _dataService.GetUserByName(username);
        if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
        {
            return null;
        }

        return user;   
    }

    public async Task<User?> Register(string username, string password, string email, string? phonenumber)
    {   
        if (await _dataService.DoesUserExist(username))
        {
            return null;
        }

        var user = new User(){ Username = username, PasswordHash = BCrypt.Net.BCrypt.HashPassword(password), Email = email, PhoneNumber = phonenumber }; 

        await _dataService.AddUser(user);
        return user;
    }
} 

    /*public int Id { get; set; }
    public required string Username { get; set; }
    public required string PasswordHash { get; set; }
    public UserRoles Role { get; set; } = UserRoles.User;
    public required string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;*/