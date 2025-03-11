using Data.Models;
using Data;

namespace Core.Services;

public interface IAuthService
{
    User? Login(string username, string password);
    User? Register(string username, string password, string email, string? phonenumber);
}

// TODO: Implement better auth
/// <summary>
/// Simple auth service to enable registering and login in, should be replaced before release
/// </summary>
public class AuthService : IAuthService
{
    private readonly IDatabase _database;

    public AuthService(IDatabase database)
    {
        _database = database;
    }

    public User? Login(string username, string password)
    {
        var user = _database.Users.FirstOrDefault(u => u.Username == username);
        if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
        {
            return null;
        }

        return user;

        /*public int Id { get; set; }
    public required string Username { get; set; }
    public required string PasswordHash { get; set; }
    public UserRoles Role { get; set; } = UserRoles.User;
    public required string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;*/
    }

    public User? Register(string username, string password, string email, string? phonenumber)
    {
        if (_database.Users.Any(u => u.Username == username))
        {
            return null;
        }

        var user = new User(){ Username = username, PasswordHash = BCrypt.Net.BCrypt.HashPassword(password), Email = email, PhoneNumber = phonenumber }; 

        _database.Users.Add(user);
        return user;
    }
} 