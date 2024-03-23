using DataAccess.DataContexts.Interfaces;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using DataAccess.Sql.FileContainers;

namespace DataAccess.Repositories;

public class FileContainerRepository(IDataContext dataContext) : IFileContainerRepository
{
    public async Task<DbViolationFile> Add(DbViolationFile model)
    {
        model.Id = Guid.NewGuid();

        return await dataContext.InsertAsync<DbViolationFile>(FileContainers.Insert, model);
    }

    public async Task<DbViolationFile> Update(DbViolationFile model)
    {
        return await dataContext.UpdateAsync<DbViolationFile>(FileContainers.Update, model);
    }

    public async Task<bool> Delete(Guid id)
    {
        return await dataContext.DeleteAsync(FileContainers.Delete, new {id});
    }

    public async Task<IEnumerable<DbViolationFile>> GetByIds(IEnumerable<Guid> ids)
    {
        return await dataContext.EnumerableOrEmptyAsync<DbViolationFile>(FileContainers.GetByIds, new {ids});
    }

    public async Task<IEnumerable<DbViolationFile>> GetByViolationIds(List<Guid> violationIds)
    {
        return await dataContext.EnumerableOrEmptyAsync<DbViolationFile>(FileContainers.GetByIds, new {violationIds});
    }
}