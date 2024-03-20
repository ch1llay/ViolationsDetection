using DataAccess.DataContexts.Interfaces;
using DataAccess.Entity;
using DataAccess.Repositories.Interfaces;
using DataAccess.Sql.ActionDirections;

namespace DataAccess.Repositories;

public class ActionDirectionRepository(IDataContext dataContext) : IActionDirectionRepository
{
    public async Task<DbActionDirection> Add(DbActionDirection model)
    {
        model.Id = Guid.NewGuid();

        return await dataContext.InsertAsync<DbActionDirection>(ActionDirections.Insert, model);
    }

    public async Task<DbActionDirection> Update(DbActionDirection model)
    {
        return await dataContext.UpdateAsync<DbActionDirection>(ActionDirections.Update, model);
    }

    public async Task<bool> Delete(Guid id)
    {
        return await dataContext.DeleteAsync(ActionDirections.Delete, new {id});
    }

    public async Task<IEnumerable<DbActionDirection>> GetByIds(IEnumerable<Guid> ids)
    {
        return await dataContext.EnumerableOrEmptyAsync<DbActionDirection>(ActionDirections.GetByIds, new {ids});
    }

    public async Task<IEnumerable<DbActionDirection>> GetByLifeSpheres(List<Guid> lifeSphereIds)
    {
        return await dataContext.EnumerableOrEmptyAsync<DbActionDirection>(ActionDirections.GetAllByLifeSpheres, new {lifeSphereIds});
    }
}
