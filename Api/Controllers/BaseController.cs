using Api.Auth;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class BaseController : Controller
{
    public string Token => HttpContext.Request.Headers["Authorization"].ToString();
    public Guid UserId => Guid.Parse(JWTParser.GetParameter<string?>(Token, "UserId") ?? string.Empty);

}