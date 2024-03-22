using Api.Controllers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.Models;

namespace Api.Controllers;

[ApiController]
[Route("violations")]
public class ViolationController(IViolationService violationService, IFileContainerService containerService) : BaseController, ICrudController<Violation, Guid>
{
    [HttpPost]
    public async Task<ActionResult<Violation>> Add(Violation model)
    {
        var violation = await violationService.Add(model);

        var newContainer = new FileContainer
        {
            Files = model.Files,
            ViolationId = violation.Id
        };

        var container = await containerService.Add(newContainer);

        return Ok(await violationService.GetById(violation.Id));
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