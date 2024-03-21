using AutoMapper;
using Common.Extensions;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using Services.Interfaces;
using Services.Models;

namespace Services;

public class FileService(
    IMapper mapper,
    IFileRepository fileRepository) : IFileService
{
    public async Task<FileModel> Add(FileModel model)
    {
        return (await fileRepository.Add(model.Map<DbFile>(mapper))).Map<FileModel>(mapper);
    }

    public async Task<FileModel> Update(FileModel model)
    {
        return (await fileRepository.Update(model.Map<DbFile>(mapper))).Map<FileModel>(mapper);
    }

    public async Task<bool> Delete(Guid id)
    {
        return await fileRepository.Delete(id);
    }

    public async Task<List<FileModel>> GetByIds(IEnumerable<Guid> ids)
    {
        var res = (await fileRepository.GetByIds(ids)).MapToList<FileModel>(mapper);

        return res;
    }

    public async Task<FileModel> GetById(Guid id)
    {
        var res = (await fileRepository.GetByIds(new List<Guid> {id})).Map<FileModel>(mapper);

        return res;
    }

    public async Task<List<FileModel>> GetByUserId(Guid userId)
    {
        var res = (await fileRepository.GetByUserIds(new List<Guid> {userId})).MapToList<FileModel>(mapper);

        return res;
    }

    public async Task<List<FileModel>> GetByContainerId(Guid containerId)
    {
        var res = (await fileRepository.GetByContainerIds(new List<Guid> {containerId})).MapToList<FileModel>(mapper);

        return res;
    }

    public async Task<List<FileModel>> GetByContainersId(List<Guid> containerIds)
    {
        var res = (await fileRepository.GetByContainerIds(containerIds)).MapToList<FileModel>(mapper);

        return res;
    }
}