using Api.Controllers.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.Models;

namespace Api.Controllers;

[ApiController]
[Authorize]
[Route("violations")]
public class ViolationController(IViolationService violationService) : BaseController, ICrudController<Violation, Guid>
{
    [HttpPost]
    public async Task<ActionResult<Violation>> Add(Violation model)
    {
        model.UserId = UserId;
        
        return Ok(await violationService.AddWithToken(model, Token));
    }

    [HttpGet("by-id")]
    public async Task<ActionResult<Violation>> GetById(Guid id)
    {
        return Ok(await violationService.GetById(id));
    }

    [HttpPut]
    public async Task<ActionResult<Violation>> Update(Violation model)
    {
        return Ok(await violationService.Update(model));
    }

    [HttpDelete]
    public async Task<ActionResult<Violation>> Delete(Guid id)
    {
        return Ok(await violationService.Delete(id));
    }

    [HttpGet("my")]
    public async Task<ActionResult<List<Violation>>> GetByUserId()
    {
        return Ok(await violationService.GetByUserId(UserId));
    }
}