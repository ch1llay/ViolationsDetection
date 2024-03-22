using Api.Controllers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.Models;

namespace Api.Controllers;

public class FileController(IFileService fileService, IFileContentService fileContentService) : Controller, ICrudController<FileModel, Guid>
{
    // GET
    public IActionResult Index()
    {
        return Ok();
    }

    [HttpPost]
    public async Task<ActionResult<FileModel>> Add(FileModel model)
    {
        var file = await fileService.Add(model);
        var content = await fileContentService.Add(model.Content);

        return await fileService.GetById(file.Id);
    }

    [HttpGet("by-id/{id}")]
    public async Task<ActionResult<FileModel>> GetById(Guid id)
    {
        return Ok(await fileService.GetById(id));
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult> Download(Guid id)
    {
        var file = await fileService.GetById(id);

        if (file == null)
        {
            return NotFound();
        }
        
        return File(file.Content.Content, file.ContentType);
    }

    public async Task<ActionResult<FileModel>> Delete(Guid id)
    {
        return Ok(await fileService.Delete(id));
    }
}