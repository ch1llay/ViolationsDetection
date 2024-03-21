using DataAccess.Entities;

namespace DataAccess.Repositories.Interfaces;

public interface IFileContentRepository : IRepository<DbFileContent>
{
    public Task<DbFileContent?> GetByFileId(Guid fileId);
}