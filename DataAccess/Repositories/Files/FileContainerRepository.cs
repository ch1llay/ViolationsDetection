using DataAccess.DataContexts.Interfaces;
using DataAccess.Entities.Files;
using DataAccess.Repositories.Files.Interfaces;
using DataAccess.Sql.ActionDirections;

namespace DataAccess.Repositories.Files;

public class FileContainerRepository(IDataContext dataContext) : IFileContainerRepository
{
    public async Task<DbFileContainer> Add(DbFileContainer model)
    {
        model.Id = Guid.NewGuid();

        return await dataContext.InsertAsync<DbFileContainer>(ActionDirections.Insert, model);
    }

    public async Task<DbFileContainer> Update(DbFileContainer model)
    {
        return await dataContext.UpdateAsync<DbFileContainer>(ActionDirections.Update, model);
    }

    public async Task<bool> Delete(Guid id)
    {
        return await dataContext.DeleteAsync(ActionDirections.Delete, new {id});
    }

    public async Task<IEnumerable<DbFileContainer>> GetByIds(IEnumerable<Guid> ids)
    {
        return await dataContext.EnumerableOrEmptyAsync<DbFileContainer>(ActionDirections.GetByIds, new {ids});
    }

    public async Task<IEnumerable<DbFileContainer>> GetByViolationIds(List<Guid> violationIds)
    {
        return await dataContext.EnumerableOrEmptyAsync<DbFileContainer>(ActionDirections.GetByIds, new {violationIds});
    }
}