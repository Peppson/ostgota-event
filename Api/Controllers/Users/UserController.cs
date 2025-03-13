namespace Api.Controllers.Events;

[Route("api/user")]
[ApiController]
public class UserController(IUserService userService) : Controller
{
    private readonly IUserService _userService = userService;
    

    [HttpGet("get")]
    public async Task<ActionResult<List<User>>> GetAllUsers()
    {
        try
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("get/name/{name}")]
    public async Task<ActionResult<User>> GetUserByName(string name)
    {
        try
        {
            var user = await _userService.GetUserByName(name);
            if (user == null)
            {
                return NotFound($"User with name: {name} was not found");
            }
            return Ok(user);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("get/id/{userId}")]
    public async Task<ActionResult<User>> GetUserById(int userId)
    {
        try
        {
            var user = await _userService.GetUserById(userId);
            if (user == null)
            {
                return NotFound($"User with id: {userId} was not found");
            }
            return Ok(user);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost("create")]
    public async Task<ActionResult<User>> CreateUser(User newUser)
    {
        try
        {
            await _userService.AddUser(newUser);
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
}
