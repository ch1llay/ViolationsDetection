using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class BaseController : Controller
{
    public Guid UserId { get; set; }
}