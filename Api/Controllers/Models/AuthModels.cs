namespace Api.Controllers.Models
{
    public record Request(string Username, string Password, string Email, string? PhoneNumber);
    public record Response(string Username, UserRole Role);
}
