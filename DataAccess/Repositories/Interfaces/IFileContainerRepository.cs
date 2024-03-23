using DataAccess.Entities;

namespace DataAccess.Repositories.Interfaces;

public interface IFileContainerRepository : IRepository<DbViolationFile>
{
    public Task<IEnumerable<DbViolationFile>> GetByViolationIds(List<Guid> violationIds);
}