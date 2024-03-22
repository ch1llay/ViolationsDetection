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

        return await dataContext.InsertAsync<DbFileContent>(Files.Insert, model);
    }

    public async Task<DbFileContent> Update(DbFileContent model)
    {
        return await dataContext.UpdateAsync<DbFileContent>(Files.Update, model);
    }

    public async Task<bool> Delete(Guid id)
    {
        return await dataContext.DeleteAsync(Files.Delete, new {id});
    }

    public async Task<IEnumerable<DbFileContent>> GetByIds(IEnumerable<Guid> ids)
    {
        return await dataContext.EnumerableOrEmptyAsync<DbFileContent>(Files.GetByIds, new {ids});
    }

    public async Task<IEnumerable<DbFileContent>> GetByFileIds(IEnumerable<Guid> fileIds)
    {
        return await dataContext.EnumerableOrEmptyAsync<DbFileContent>(Files.GetByIds, new {fileIds});
    }
}