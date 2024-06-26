﻿using AutoMapper;
using Common.Extensions;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using Services.Interfaces;
using Services.Models;

namespace Services;

public class FileService(
    IMapper mapper,
    IFileRepository fileRepository,
    IFileContentRepository fileContentRepository) : IFileService
{
    public async Task<FileModel?> Add(FileModel model)
    {
        var file = await fileRepository.Add(model.Map<DbFile>(mapper));

        var fileContent = await fileContentRepository.Add(new DbFileContent
        {
            FileId = file.Id,
            Content = model.Content
        });

        if (fileContent == null)
        {
            return null;
        }

        return file.Map<FileModel>(mapper);
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
    
    public async Task<FileModel> GetByIdWithContent(Guid id)
    {
        var file = (await fileRepository.GetByIds(new List<Guid> {id})).MapToList<FileModel>(mapper).FirstOrDefault();

        if (file == null)
        {
            return null;
        }

        var content = (await fileContentRepository.GetByFileIds(new[] {file.Id})).FirstOrDefault();

        file.Content = content?.Content;

        return file;
    }
}