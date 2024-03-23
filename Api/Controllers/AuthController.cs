using Api.Auth;
using Api.Contracts;
using Api.Extensions;
using AutoMapper;
using Common.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.Models;

namespace Api.Controllers;

[ApiController]
[Route("access")]
public class AuthController(IMapper mapper, IUserService userService) : Controller
{
    [HttpPost("reg")]
    public async Task<IActionResult> Registration(RegRequest regUser, [FromQuery] bool withHash = false)
    {
        var user = await userService.GetByLogin(regUser.Login);

        regUser.Password = withHash
            ? regUser.Password
            : regUser.Password.HashString();

        if (user != null)
        {
            return BadRequest("Пользатель с таким логином уже существует");
        }

        return Ok(await userService.Add(regUser.Map<User>(mapper)));
    }

    [HttpPost("auth")]
    public async Task<IActionResult> Index(AuthReq authReq, [FromQuery] bool withHash)
    {
        var user = await userService.GetByLogin(authReq.Login);

        var processingPassword = withHash
            ? authReq.Password
            : authReq.Password.HashString();

        if (processingPassword != user?.PasswordHash)
        {
            return Forbid();
        }

        return Ok(new AuthResp
        {
            AccessToken = JWTGenerator.Generate(new Dictionary<string, string>{{"UserId", user.Id.ToString()}} ),
            User = user,
            Success = true
        });
    }

    [Authorize]
    [HttpGet("enter")]
    public Task<IActionResult> Test()
    {
        var token = HttpContext.GetToken();

        var userId = JWTParser.GetParameter<string>(token, "UserId");

        return Task.FromResult<IActionResult>(Ok($"UserId: {userId}"));
    }
}