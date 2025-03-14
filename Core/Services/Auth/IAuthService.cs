namespace Core.Services.Auth;

public interface IAuthService
{
    Task<User?> Login(string username, string password);
    Task<User?> Register(string username, string password, string email, string? phonenumber);
}
