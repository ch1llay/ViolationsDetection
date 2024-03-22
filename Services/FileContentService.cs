using AutoMapper;
using Common.Extensions;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using Services.Interfaces;
using Services.Models;

namespace Services;

public class FileContentService(
    IMapper mapper,
    IFileContentRepository fileContentRepository) : IFileContentService
{
    public async Task<FileContent> Add(FileContent model)
    {
        return (await fileContentRepository.Add(model.Map<DbFileContent>(mapper))).Map<FileContent>(mapper);
    }

    public async Task<FileContent> Update(FileContent model)
    {
        return (await fileContentRepository.Update(model.Map<DbFileContent>(mapper))).Map<FileContent>(mapper);
    }

    public async Task<bool> Delete(Guid id)
    {
        return await fileContentRepository.Delete(id);
    }

    public async Task<List<FileContent>> GetByIds(IEnumerable<Guid> ids)
    {
        var res = (await fileContentRepository.GetByIds(ids)).MapToList<FileContent>(mapper);

        return res;
    }

    public async Task<FileContent> GetById(Guid id)
    {
        var res = (await fileContentRepository.GetByIds(new List<Guid> {id})).Map<FileContent>(mapper);

        return res;
    }

    public async Task<FileContent> GetByFileId(Guid fileId)
    {
        var res = (await fileContentRepository.GetByFileIds(new List<Guid> {fileId})).Map<FileContent>(mapper);

        return res;
    }

    public Task<List<FileContent>> GetByFileIds(Guid fileId)
    {
        throw new NotImplementedException();
    }
}