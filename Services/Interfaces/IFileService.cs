using Services.Models;

namespace Services.Interfaces;

public interface IFileService : ICrudService<FileModel, Guid>
{
    public Task<List<FileModel>> GetByUserId(Guid lifeSphereId);
    public Task<FileModel> GetByIdWithContent(Guid fileId);
    public Task<List<FileModel>> GetByContainerId(Guid containerId);
    public Task<List<FileModel>> GetByContainersId(List<Guid> containerIds);
}