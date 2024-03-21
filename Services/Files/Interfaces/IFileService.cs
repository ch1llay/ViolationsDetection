using Services.Interfaces;
using Services.Models.Files;

namespace Services.Files.Interfaces;

public interface IFileService : ICrudService<FileModel, Guid>
{
    public Task<List<FileModel>> GetByUserId(Guid lifeSphereId);
    public Task<List<FileModel>> GetByContainerId(Guid containerId);
}