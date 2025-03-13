namespace Core.Services;

// TODO: Implement better auth
/// <summary>
/// Simple auth service to enable registering and login in, should be replaced before release
/// </summary>
public class AuthService : IAuthService
{
    private readonly IUserService _userService;

    public AuthService(IUserService dataService)
    {
        _userService = dataService;
    }
 
    public async Task<User?> Login(string username, string password)
    {
        var user = await _userService.GetUserByName(username);
        if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
        {
            return null;
        }

        return user;   
    }

    public async Task<User?> Register(string username, string password, string email, string? phonenumber)
    {   
        if (await _userService.DoesUserExist(username))
        {
            return null;
        }

        var user = new User(){ Username = username, PasswordHash = BCrypt.Net.BCrypt.HashPassword(password), Email = email, PhoneNumber = phonenumber }; 

        await _userService.AddUser(user);
        return user;
    }
} 
