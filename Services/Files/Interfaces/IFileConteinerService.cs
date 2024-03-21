using Services.Interfaces;
using Services.Models.Files;

namespace Services.Files.Interfaces;

public interface IFileContainerService : ICrudService<FileContainer, Guid>
{
    public Task<FileContainer> GetByViolationId(Guid lifeSphereId);
}