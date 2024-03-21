using Api.Controllers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Services.Models.Files;

namespace Api.Controllers;

public class FileController : Controller, ICrudController<FileModel, Guid>
{
    // GET
    public IActionResult Index()
    {
        return Ok();
    }

    public Task<ActionResult<FileModel>> Add(FileModel model)
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult<FileModel>> GetById(Guid id)
    {
        throw new NotImplementedException();
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