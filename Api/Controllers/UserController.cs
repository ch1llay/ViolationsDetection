using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class UserController : Controller
{
    // GET
    public IActionResult Index()
    {
        return Ok();
    }
}