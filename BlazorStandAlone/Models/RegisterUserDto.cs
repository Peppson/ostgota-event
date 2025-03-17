namespace BlazorStandAlone.Models
{
    public record RegisterUserDto(string Username, string Email, string? PhoneNumber, UserRole Role);
}
