using DataAccess.DataContexts.Interfaces;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using DataAccess.Sql.Files;

namespace DataAccess.Repositories;

public class FileRepository(IDataContext dataContext) : IFileRepository
{
    public async Task<DbFile> Add(DbFile model)
    {
        model.Id = Guid.NewGuid();

        return await dataContext.InsertAsync<DbFile>(Files.Insert, model);
    }

    public async Task<DbFile> Update(DbFile model)
    {
        return await dataContext.UpdateAsync<DbFile>(Files.Update, model);
    }

    public async Task<bool> Delete(Guid id)
    {
        return await dataContext.DeleteAsync(Files.Delete, new {id});
    }

    public async Task<IEnumerable<DbFile>> GetByIds(IEnumerable<Guid> ids)
    {
        return await dataContext.EnumerableOrEmptyAsync<DbFile>(Files.GetByIds, new {ids});
    }


    public async Task<IEnumerable<DbFile>> GetByUserIds(List<Guid> userIds)
    {
        return await dataContext.EnumerableOrEmptyAsync<DbFile>(Files.GetAllByLifeSpheres, new {userIds});
    }

    public async Task<IEnumerable<DbFile>> GetByContainerIds(List<Guid> containerIds)
    {
        return await dataContext.EnumerableOrEmptyAsync<DbFile>(Files.GetAllByLifeSpheres, new {containerIds});
    }
}