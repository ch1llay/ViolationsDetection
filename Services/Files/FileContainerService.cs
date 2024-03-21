using AutoMapper;
using Common.Extensions;
using DataAccess.Entities.Files;
using DataAccess.Repositories.Files.Interfaces;
using Services.Files.Interfaces;
using Services.Models.Files;

namespace Services.Files;

public class FileContainerService(
    IMapper mapper,
    IFileContainerRepository fileContainerRepository,
    IFileService fileService) : IFileContainerService
{
    public async Task<FileContainer> Add(FileContainer model)
    {
        return (await fileContainerRepository.Add(model.Map<DbFileContainer>(mapper))).Map<FileContainer>(mapper);
    }

    public async Task<FileContainer> Update(FileContainer model)
    {
        return (await fileContainerRepository.Update(model.Map<DbFileContainer>(mapper))).Map<FileContainer>(mapper);
    }

    public async Task<bool> Delete(Guid id)
    {
        return await fileContainerRepository.Delete(id);
    }

    public async Task<List<FileContainer>> GetByIds(IEnumerable<Guid> ids)
    {
        var res = (await fileContainerRepository.GetByIds(ids)).MapToList<FileContainer>(mapper);

        return res;
    }

    public async Task<FileContainer> GetById(Guid id)
    {
        var res = (await fileContainerRepository.GetByIds(new List<Guid> {id})).Map<FileContainer>(mapper);

        return res;
    }

    public async Task<FileContainer> GetByViolationId(Guid violationId)
    {
        var res = (await fileContainerRepository.GetByViolationIds(new List<Guid> {violationId})).Map<FileContainer>(mapper);

        return res;
    }
}

public static class FileContainerExtensions
{
    public static async Task<FileContainer> GetFiles(this FileContainer fileContainer,
        IFileService fileService)
    {
        var files = await fileService.GetByContainerId(fileContainer.Id);
        fileContainer.Files = files;

        return fileContainer;
    }
}