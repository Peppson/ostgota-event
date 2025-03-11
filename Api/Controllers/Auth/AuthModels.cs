using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Auth
{
    public record Request(string Username, string Password);
    public record Response(string Username, UserRoles Role);
}
