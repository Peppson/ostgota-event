using Core.Services;
using Data.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Auth
{
    public class RegisterController : Controller
    {

        public static Results<Ok<Response>, BadRequest<string>> Handle( Request request, IAuthService authService)
        {
            var result = authService.Register(request.Username, request.Password);
            if (result == null)
            {
                return TypedResults.BadRequest("Username already exists");
            }
            var response = new Response(result.Username, result.Role);
            return TypedResults.Ok(response);
        }
    }
}

