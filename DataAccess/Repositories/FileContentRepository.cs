using DataAccess.DataContexts.Interfaces;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using DataAccess.Sql.Files;

namespace DataAccess.Repositories;

public class FileContentRepository(IDataContext dataContext) : IFileContentRepository
{
    public async Task<DbFileContent> Add(DbFileContent model)
    {
        model.Id = Guid.NewGuid();

        return await dataContext.InsertAsync<DbFileContent>(Files.InsertFileContent, model);
    }

    public async Task<DbFileContent> Update(DbFileContent model)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<DbFileContent>> GetByIds(IEnumerable<Guid> ids)
    {
        return await dataContext.EnumerableOrEmptyAsync<DbFileContent>(Files.GetByIds, new {ids});
    }

    public async Task<IEnumerable<DbFileContent>> GetByFileIds(IEnumerable<Guid> fileIds)
    {
        return await dataContext.EnumerableOrEmptyAsync<DbFileContent>(Files.GetFileContentByFileIds, new {fileIds});
    }
}