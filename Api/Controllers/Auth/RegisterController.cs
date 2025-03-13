namespace Api.Controllers.Auth;

[Route("api/auth/register")]
[ApiController]
public class RegisterController(IAuthService authService) : Controller
{
    private readonly IAuthService _authService = authService;
    [HttpPost]
    public async Task<IActionResult> Handle([FromBody]RegisterRequest request)
    {   
        // Sorry Viktor, var tvungen att greja lite här för att få skiten att kompilera :) - JeppaJogg
        var result = await _authService.Register(request.Username, request.Password, request.Email, request.PhoneNumber); // <<<<< denna null
        if (result == null)
        {
            return BadRequest("Username already exists");
        }
        var response = new Response(result.Username, result.Role);
        return Created("User created", response);
    }
}
