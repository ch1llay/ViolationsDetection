using Api.Controllers.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.Models;

namespace Api.Controllers;

[ApiController]
[Authorize]
[Route("files")]
public class FileController(IFileService fileService) : BaseController
{
    [HttpPost]
    public async Task<ActionResult<Guid>> Add(IFormFile formFile)
    {
        using var memoryStream = new MemoryStream();
        await formFile.CopyToAsync(memoryStream);
        var fileModel = new FileModel
        {
            Filename = formFile.FileName,
            ContentType = formFile.ContentType,
            CreatedDate = DateTime.Now,
            UserId = UserId,
            Content = memoryStream.ToArray()
        };
            
        var file = await fileService.Add(fileModel);

        return file.Id;
    }

    [HttpGet("by-id/{id}")]
    public async Task<ActionResult<FileModel>> GetById(Guid id)
    {
        return Ok(await fileService.GetById(id));
    }

    [HttpDelete]
    public async Task<ActionResult<FileModel>> Delete(Guid id)
    {
        return Ok(await fileService.Delete(id));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> Download(Guid id)
    {
        var file = await fileService.GetByIdWithContent(id);

        if (file == null)
        {
            return NotFound();
        }

        return File(file.Content, file.ContentType);
    }
}