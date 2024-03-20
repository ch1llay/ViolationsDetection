using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class FileController : Controller
{
    // GET
    public IActionResult Index()
    {
        return Ok();
    }
}