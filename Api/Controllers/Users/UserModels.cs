namespace Api.Controllers.Users;

public record AllUsersDTO
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public UserRole Role { get; set; }
    public DateTime CreatedAt { get; set; }
}

public record UserDTO
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public UserRole Role { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<UserTicketDTO> Tickets { get; set; } = [];
}

public record UserTicketDTO
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int EventId { get; set; }
    public decimal Price { get; set; }
    public string? Seat { get; set; } 
}
