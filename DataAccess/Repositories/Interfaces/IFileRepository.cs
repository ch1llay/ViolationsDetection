using DataAccess.Entities;

namespace DataAccess.Repositories.Interfaces;

public interface IFileRepository : IRepository<DbFileModel>
{
    public Task<IEnumerable<DbFileModel>> GetByUserIds(List<Guid> userIds);
    public Task<IEnumerable<DbFileModel>> GetByContainerIds(List<Guid> containerIds);
}