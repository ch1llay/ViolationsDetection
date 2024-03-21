using Api.Controllers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.Models.Violations;

namespace Api.Controllers;

public class ViolationController(IViolationService violationService) : BaseController, ICrudController<Violation, Guid>
{
    [HttpPost]
    public Task<ActionResult<Violation>> Add(Violation model)
    {
        throw new NotImplementedException();
    }

    [HttpGet("by-id")]
    public async Task<ActionResult<Violation>> GetById(Guid id)
    {
        return Ok(await violationService.GetById(id));
    }
    
    [HttpGet("by-userId/{userId}")]
    public async Task<ActionResult<List<Violation>>> GetByUserId(Guid userId)
    {
        return Ok(await violationService.GetByUserId(userId));
    }

    public Task<ActionResult<Violation>> Update(Violation model)
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult<Violation>> Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}