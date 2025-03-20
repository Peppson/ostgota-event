namespace Api.Controllers.Auth;

public record RegisterRequest(string Username, string Password, string Email, string? PhoneNumber);
public record Response(string Username);
public record LoginRequest(string Username, string Password);
