using Api.Controllers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.Models.Files;

namespace Api.Controllers;

public class FileController(IFileService fileService) : Controller, ICrudController<FileModel, Guid>
{
    // GET
    public IActionResult Index()
    {
        return Ok();
    }

    [HttpPost]
    public async Task<ActionResult<FileModel>> Add(FileModel model)
    {
        return Ok(await fileService.Add(model));
    }

    [HttpGet("by-id/{id}")]
    public async Task<ActionResult<FileModel>> GetById(Guid id)
    {
        return Ok(await fileService.GetById(id));
    }

    public Task<ActionResult<FileModel>> Update(FileModel model)
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult<FileModel>> Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}