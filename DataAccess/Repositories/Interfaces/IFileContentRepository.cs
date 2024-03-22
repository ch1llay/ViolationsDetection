using System.Collections;
using DataAccess.Entities;

namespace DataAccess.Repositories.Interfaces;

public interface IFileContentRepository : IRepository<DbFileContent>
{
    public Task<IEnumerable<DbFileContent>> GetByFileIds(IEnumerable<Guid> fileIds);
}