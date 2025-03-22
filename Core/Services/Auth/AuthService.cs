namespace Core.Services.Auth;

public class AuthService(IUserService userService) : IAuthService
{
    private readonly IUserService _userService = userService;

    public async Task<User?> Login(string username, string password)
    {
        var user = await _userService.GetUserByName(username);
        if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            return null;

        return user;   
    }

    public async Task<User?> Register(string username, string password, string email, string? phoneNumber)
    {   
        if (await _userService.DoesUserExist(username))
            return null;

        var user = new User()
        { 
            Username = username, 
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(password), 
            Email = email, 
            PhoneNumber = phoneNumber 
        }; 

        await _userService.AddUser(user);
        return user;
    }
} 
