using Services.Models.Files;

namespace Services.Interfaces;

public interface IFileContainerService : ICrudService<FileContainer, Guid>
{
    public Task<FileContainer> GetByViolationId(Guid lifeSphereId);
}