using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : Controller
{
    private readonly IMapper _mapper;
    private readonly IUserService _userService;

    public UserController(IMapper mapper, IUserService userService)
    {
        _mapper = mapper;
        _userService = userService;
    }

    [Authorize]
    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _userService.GetAll());
    }

    [Authorize]
    [HttpGet("by-id/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return Ok(await _userService.GetById(id));
    }
}