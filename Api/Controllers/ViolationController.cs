using Api.Controllers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.Models;

namespace Api.Controllers;

[ApiController]
[Route("violations")]
public class ViolationController(IViolationService violationService) : BaseController, ICrudController<Violation, Guid>
{
    [HttpPost]
    public async Task<ActionResult<Violation>> Add(Violation model)
    {
        return Ok(await violationService.Add(model));
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

    [HttpGet("by-userId/{userId}")]
    public async Task<ActionResult<List<Violation>>> GetByUserId(Guid userId)
    {
        return Ok(await violationService.GetByUserId(userId));
    }
}