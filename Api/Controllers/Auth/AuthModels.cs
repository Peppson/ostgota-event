namespace Api.Controllers.Auth;

public record RegisterRequest(string Username, string Password, string Email, string? PhoneNumber);
public record Response(string Username, UserRole Role);
public record LoginRequest(string Username, string Password);
