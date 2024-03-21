using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;

namespace DataAccess.Repositories;

public interface IViolationRepository : IRepository<DbViolation>
{
    public Task<IEnumerable<DbViolation>> GetByUserId(List<Guid> userIds);
}