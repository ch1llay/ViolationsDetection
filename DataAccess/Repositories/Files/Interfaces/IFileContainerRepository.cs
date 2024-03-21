using DataAccess.Entities.Files;
using DataAccess.Repositories.Interfaces;

namespace DataAccess.Repositories.Files.Interfaces;

public interface IFileContainerRepository : IRepository<DbFileContainer>
{
    public Task<IEnumerable<DbFileContainer>> GetByViolationIds(List<Guid> violationIds);
}