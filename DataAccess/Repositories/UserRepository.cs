using DataAccess.DataContexts.Interfaces;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using DataAccess.Sql.Users;

namespace DataAccess.Repositories;

public class UserRepository(IDataContext dataContext) : IUserRepository
{
    public async Task<DbUser> Add(DbUser model)
    {
        model.Id = Guid.NewGuid();

        return await dataContext.InsertAsync<DbUser>(Users.Insert, model);
    }

    public async Task<DbUser> Update(DbUser model)
    {
        return await dataContext.UpdateAsync<DbUser>(Users.Update, model);
    }

    public async Task<bool> Delete(Guid id)
    {
        return await dataContext.DeleteAsync(Users.Delete, new {id});
    }

    public async Task<IEnumerable<DbUser>> GetByIds(IEnumerable<Guid> ids)
    {
        return await dataContext.EnumerableOrEmptyAsync<DbUser>(Users.GetByIds, new {ids});
    }
    
}