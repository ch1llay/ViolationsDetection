using Services.Models;

namespace Services.Interfaces;

public interface IFileContentService : ICrudService<FileContent, Guid>
{
    public Task<FileContent> GetByFileId(Guid fileId);
    public Task<List<FileContent>> GetByFileIds(Guid fileId);
}