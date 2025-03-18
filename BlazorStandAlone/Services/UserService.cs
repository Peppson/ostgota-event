using Core.Models;
using System.Net.Http.Json;

namespace BlazorStandAlone.Services
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllUsers();
        Task<UserDto?> GetUserById(int id);
        Task<bool> CreateUser(UserDto user);
        Task<bool> UpdateUser(UserDto user);
        Task<bool> DeleteUser(int id);
        List<TicketDto> GetUserTickets(int userId);
        List<UserDto> Users { get; }
        int UserCount { get; }
    }

    public class UserServiceException : Exception
    {
        public UserServiceException(string message, Exception? inner = null) 
            : base(message, inner) { }
    }

    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        private List<UserDto> _users = new();
        private List<TicketDto> _tickets = new();

        public List<UserDto> Users => _users;
        public int UserCount => _users.Count;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<UserDto>> GetAllUsers()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/user/get");
                if (response.IsSuccessStatusCode)
                {
                    _users = await response.Content.ReadFromJsonAsync<List<UserDto>>() ?? new();
                    foreach (var user in _users)
                    {
                        user.Tickets = GetUserTickets(user.Id);
                    }
                    return _users;
                }
                throw new UserServiceException($"Failed to fetch users: {response.StatusCode}");
            }
            catch (Exception ex) when (ex is not UserServiceException)
            {
                throw new UserServiceException("An error occurred while fetching users", ex);
            }
        }

        public List<TicketDto> GetUserTickets(int userId)
        {
            return _tickets.Where(t => t.UserId == userId).ToList();
        }

        public async Task<UserDto?> GetUserById(int id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

        public async Task<bool> CreateUser(UserDto user)
        {
            try
            {
                var newUser = new RegisterUserDto(user.Username, user.Email, user.PhoneNumber, user.Role);
                var response = await _httpClient.PostAsJsonAsync("api/user/create", newUser);
                
                if (response.IsSuccessStatusCode)
                {
                    await GetAllUsers(); // Refresh the list
                    return true;
                }
                throw new UserServiceException($"Failed to create user: {response.ReasonPhrase}");
            }
            catch (Exception ex) when (ex is not UserServiceException)
            {
                throw new UserServiceException("An error occurred while creating user", ex);
            }
        }

        public async Task<bool> UpdateUser(UserDto user)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/user/update/{user.Id}", user);
                if (response.IsSuccessStatusCode)
                {
                    await GetAllUsers(); // Refresh the list
                    return true;
                }
                throw new UserServiceException($"Failed to update user: {response.StatusCode}");
            }
            catch (Exception ex) when (ex is not UserServiceException)
            {
                throw new UserServiceException("An error occurred while updating user", ex);
            }
        }

        public async Task<bool> DeleteUser(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/user/delete/{id}");
                if (response.IsSuccessStatusCode)
                {
                    await GetAllUsers(); // Refresh the list
                    return true;
                }
                throw new UserServiceException($"Failed to delete user: {response.StatusCode}");
            }
            catch (Exception ex) when (ex is not UserServiceException)
            {
                throw new UserServiceException("An error occurred while deleting user", ex);
            }
        }

        public void UpdateTickets(List<TicketDto> tickets)
        {
            _tickets = tickets;
        }
    }
}
