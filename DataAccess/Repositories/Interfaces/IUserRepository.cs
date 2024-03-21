using DataAccess.Entities;

namespace DataAccess.Repositories.Interfaces;

public interface IUserRepository : IRepository<DbUser>
{
    public Task<IEnumerable<DbUser>> GetByUserIds(List<Guid> userIds);
}