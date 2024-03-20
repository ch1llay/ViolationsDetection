using DataAccess.DataContexts.Interfaces;
using DataAccess.Entities.Users;
using DataAccess.Repositories.Users.Interfaces;
using DataAccess.Sql.ActionDirections;

namespace DataAccess.Repositories.Users;

public class FileRepository(IDataContext dataContext) : IUserRepository
{
    public async Task<DbUser> Add(DbUser model)
    {
        model.Id = Guid.NewGuid();

        return await dataContext.InsertAsync<DbUser>(ActionDirections.Insert, model);
    }

    public async Task<DbUser> Update(DbUser model)
    {
        return await dataContext.UpdateAsync<DbUser>(ActionDirections.Update, model);
    }

    public async Task<bool> Delete(Guid id)
    {
        return await dataContext.DeleteAsync(ActionDirections.Delete, new {id});
    }

    public async Task<IEnumerable<DbUser>> GetByIds(IEnumerable<Guid> ids)
    {
        return await dataContext.EnumerableOrEmptyAsync<DbUser>(ActionDirections.GetByIds, new {ids});
    }

    public async Task<IEnumerable<DbUser>> GetByUserId(List<Guid> userIds)
    {
        return await dataContext.EnumerableOrEmptyAsync<DbUser>(ActionDirections.GetAllByLifeSpheres, new {userIds});
    }
    
}
