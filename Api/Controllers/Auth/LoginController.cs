using Microsoft.AspNetCore.Http.HttpResults;

namespace Api.Controllers.Auth
{
    [Route("api/auth/login")]
    [ApiController]
    public class LoginController : Controller
    {

        [HttpPost]
        public static async Task<Results<Ok<Response>, NotFound<string>>> LogIn(Request request, IAuthService authService, HttpContext context)
        {
            var result = await authService.Login(request.Username, request.Password); //authorizes the login from userinput by authentication service.
            if (result == null)
            {
                return TypedResults.NotFound("Invalid username or password");
            }

            // Set a simple auth cookie
            context.Response.Cookies.Append("auth", $"{result.Username}:{result.Role}", new CookieOptions
            {
                HttpOnly = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTimeOffset.UtcNow.AddDays(7)
            });
            var response = new Response(result.Username, result.Role);
            return TypedResults.Ok(response);
        }
    }

}
