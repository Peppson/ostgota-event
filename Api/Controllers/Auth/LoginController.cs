using Microsoft.AspNetCore.Http.HttpResults;

namespace Api.Controllers.Auth
{
    [Route("api/auth/login")]
    [ApiController]
    public class LoginController(IAuthService authService /* HttpContext context*/) : Controller
    {
        private readonly IAuthService _authService = authService;
        //private readonly HttpContext _context = context;

        [HttpPost]
        public async Task<IActionResult> LogIn([FromBody]LoginRequest request)
        {
            var result = await _authService.Login(request.Username, request.Password); //authorizes the login from userinput by authentication service.
            if (result == null)
            {
                return NotFound("Invalid username or password");
            }

            // Set a simple auth cookie
            /*_context.Response.Cookies.Append("auth", $"{result.Username}:{result.Role}", new CookieOptions
            {
                HttpOnly = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTimeOffset.UtcNow.AddDays(7)
            });*/
            var response = new Response(result.Username, result.Role);
            return Ok(response);
        }
    }

}
