using DataAccess.Entities.Users;
using DataAccess.Repositories.Interfaces;

namespace DataAccess.Repositories.Users.Interfaces;

public interface IFileRepository : IRepository<DbUser>
{
    public Task<IEnumerable<DbUser>> GetByUserId(List<Guid> userIds);
}
