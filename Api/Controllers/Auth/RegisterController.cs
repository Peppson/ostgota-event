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
            // Sorry Viktor, var tvungen att greja lite här för att få skiten att kompilera :) - JeppaJogg
            var result = authService.Register(request.Username, request.Password, request.Email, null); // <<<<< 
            if (result == null)
            {
                return TypedResults.BadRequest("Username already exists");
            }
            var response = new Response(result.Username, result.Role);
            return TypedResults.Ok(response);
        }
    }
}

