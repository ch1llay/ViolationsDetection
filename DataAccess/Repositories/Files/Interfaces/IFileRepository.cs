using DataAccess.Entities.Files;
using DataAccess.Repositories.Interfaces;

namespace DataAccess.Repositories.Files.Interfaces;

public interface IFileRepository : IRepository<DbFileModel>
{
    public Task<IEnumerable<DbFileModel>> GetByUserIds(List<Guid> userIds);
    public Task<IEnumerable<DbFileModel>> GetByContainerIds(List<Guid> containerIds);
}