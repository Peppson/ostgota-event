namespace Api.Controllers.Auth;

public record Request(string Username, string Password, string Email);
public record Response(string Username, UserRole Role);
