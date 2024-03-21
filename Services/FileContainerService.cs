using AutoMapper;
using Common.Extensions;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using Services.Interfaces;
using Services.Models.Files;

namespace Services;

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
        await res.GetFiles(fileService);

        return res;
    }

    public async Task<FileContainer> GetById(Guid id)
    {
        var res = (await fileContainerRepository.GetByIds(new List<Guid> {id})).Map<FileContainer>(mapper);
        await res.GetFiles(fileService);

        return res;
    }

    public async Task<FileContainer> GetByViolationId(Guid violationId)
    {
        var res = (await fileContainerRepository.GetByViolationIds(new List<Guid> {violationId})).Map<FileContainer>(mapper);
        await res.GetFiles(fileService);

        return res;
    }

    public async Task<List<FileContainer>> GetByViolationIds(List<Guid> violationIds)
    {
        var res = (await fileContainerRepository.GetByViolationIds(violationIds)).MapToList<FileContainer>(mapper);
        await res.GetFiles(fileService);

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
    
    public static async Task<List<FileContainer>> GetFiles(this List<FileContainer> fileContainers,
        IFileService fileService)
    {
        var containerIds = fileContainers.Select(f => f.Id).ToList();
        var files = await fileService.GetByContainersId(containerIds);
        var filesGroupByContainerId = files.GroupBy(f => f.FileContainerId).ToDictionary(t => t.Key, t => t.ToList());
        
        fileContainers.ForEach(f=>f.Files = filesGroupByContainerId.GetValueOrDefault(f.Id) ?? new List<FileModel>());

        return fileContainers;
    }
}