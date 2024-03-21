using DataAccess.Entities;

namespace DataAccess.Repositories.Interfaces;

public interface IFileRepository : IRepository<DbFile>
{
    public Task<IEnumerable<DbFile>> GetByUserIds(List<Guid> userIds);
    public Task<IEnumerable<DbFile>> GetByContainerIds(List<Guid> containerIds);
}