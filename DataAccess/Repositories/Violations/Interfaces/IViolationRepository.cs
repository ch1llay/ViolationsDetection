using DataAccess.Entities.Violations;
using DataAccess.Repositories.Interfaces;

namespace DataAccess.Repositories.Violations.Interfaces;

public interface IViolationRepository : IRepository<DbViolation>
{
    public Task<IEnumerable<DbViolation>> GetByUserId(List<Guid> userIds);
}
