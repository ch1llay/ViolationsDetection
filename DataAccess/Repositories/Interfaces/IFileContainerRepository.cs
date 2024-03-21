using DataAccess.Entities;

namespace DataAccess.Repositories.Interfaces;

public interface IFileContainerRepository : IRepository<DbFileContainer>
{
    public Task<IEnumerable<DbFileContainer>> GetByViolationIds(List<Guid> violationIds);
}