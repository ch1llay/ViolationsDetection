using Services.Models;

namespace Services.Interfaces;

public interface IFileContainerService : ICrudService<FileContainer, Guid>
{
    public Task<FileContainer> GetByViolationId(Guid lifeSphereId);
    public Task<List<FileContainer>> GetByViolationIds(List<Guid> lifeSphereId);
}