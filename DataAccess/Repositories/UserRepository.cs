using DataAccess.DataContexts.Interfaces;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using DataAccess.Sql.Users;

namespace DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IDataContext _dataContext;

    public UserRepository(IDataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<IEnumerable<DbUser>> GetAll()
    {
        return await _dataContext.EnumerableOrEmptyAsync<DbUser>(Users.GetAll, new { });
    }

    public async Task<DbUser> Add(DbUser model)
    {
        return await _dataContext.InsertAsync<DbUser>(Users.Insert, model);
    }

    public async Task<DbUser> Update(DbUser model)
    {
        return await _dataContext.UpdateAsync<DbUser>(Users.Insert, model);
    }

    public Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<DbUser>> GetByIds(IEnumerable<Guid> ids)
    {
        return await _dataContext.EnumerableOrEmptyAsync<DbUser>(Users.GetByIds, new {ids});
    }


    public async Task<DbUser?> GetByLogin(string login)
    {
        return await _dataContext.FirstOrDefaultAsync<DbUser>(Users.GetByLogin, new {login});
    }
}