using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class ViolationController : Controller
{
    // GET
    public IActionResult Index()
    {
        return Ok();
    }
}