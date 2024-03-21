using DataAccess.Entities.Users;
using DataAccess.Repositories.Interfaces;

namespace DataAccess.Repositories.Users.Interfaces;

public interface IUserRepository : IRepository<DbUser>
{
    public Task<IEnumerable<DbUser>> GetByUserIds(List<Guid> userIds);
}