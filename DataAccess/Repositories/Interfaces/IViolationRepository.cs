using DataAccess.Entities;

namespace DataAccess.Repositories.Interfaces;

public interface IViolationRepository : IRepository<DbViolation>
{
    public Task<IEnumerable<DbViolation>> GetByUserId(List<Guid> userIds);
    public Task<int> AddViolationFiles(List<DbViolationFile> violationFile);
    public Task<IEnumerable<DbViolationFile>> GetViolationFilesByViolationIds(List<Guid> violationIds);
}