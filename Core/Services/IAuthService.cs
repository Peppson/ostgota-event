namespace Core.Services;

public interface IAuthService
{
    User? Login(string username, string password);
    User? Register(string username, string password, string email, string? phonenumber);
}
