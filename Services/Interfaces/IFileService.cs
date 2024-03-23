using Services.Models;

namespace Services.Interfaces;

public interface IFileService : ICrudService<FileModel, Guid>
{
    public Task<List<FileModel>> GetByUserId(Guid lifeSphereId);
    public Task<FileModel> GetByIdWithContent(Guid fileId);
}