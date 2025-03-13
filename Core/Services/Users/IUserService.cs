namespace Core.Services.Users;

public interface IUserService
{
    Task<User?> GetUserByName(string username);
    Task<bool> DoesUserExist(string username);
    Task<List<User>> GetAllUsers();
    Task AddUser(User user);
    Task RemoveUser(User user);
}
