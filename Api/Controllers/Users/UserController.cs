namespace Api.Controllers.Users;

[Route("api/user")]
[ApiController]
public class UserController(IUserService userService) : Controller
{
    private readonly IUserService _userService = userService;
    

    [HttpGet("get")]
    public async Task<ActionResult<List<AllUsersDTO>>> GetAllUsers()
    {
        try
        {
            var users = await _userService.GetAllUsers();
            return Ok( GetAllUsersDTO(users) );
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("get/name/{name}")]
    public async Task<ActionResult<UserDTO>> GetUserByName(string name)
    {
        try
        {
            var user = await _userService.GetUserByName(name);
            if (user == null)
                return NotFound($"User with name: {name} was not found");

            var newUser = new UserDTO
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Role = user.Role,
                CreatedAt = user.CreatedAt,
                Tickets = GetTicketDTO(user.Tickets)
            };
            
            return Ok(newUser);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("get/id/{userId}")]
    public async Task<ActionResult<UserDTO>> GetUserById(int userId)
    {
        try
        {
            var user = await _userService.GetUserById(userId);
            if (user == null)
                return NotFound($"User with name: {userId} was not found");

            var newUser = new UserDTO
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Role = user.Role,
                CreatedAt = user.CreatedAt,
                Tickets = GetTicketDTO(user.Tickets)
            };
            
            return Ok(newUser);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpDelete("delete/{id}")]
    public async Task<ActionResult<User>> DeleteUserById(int id)
    {
        try
        {   
            if (!await _userService.RemoveUserById(id))
                return NotFound("User not found.");

            return Ok(id);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    private static List<AllUsersDTO> GetAllUsersDTO(List<User> users)
    {
        return users.Select(t => new AllUsersDTO
        {
            Id = t.Id,
            Username = t.Username,
            Email = t.Email,
            PhoneNumber = t.PhoneNumber,
            Role = t.Role,
            CreatedAt = t.CreatedAt
        }).ToList();
    }

    private static List<UserTicketDTO> GetTicketDTO(List<Ticket> tickets)
    {
        return tickets.Select(t => new UserTicketDTO
        {   
            Id = t.Id,
            UserId = t.UserId,
            EventId = t.EventId,
            Price = t.Price,
            Seat = t.Seat
        }).ToList();
    }
}
