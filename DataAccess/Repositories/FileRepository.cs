using DataAccess.DataContexts.Interfaces;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using DataAccess.Sql.Files;

namespace DataAccess.Repositories;

public class FileRepository(IDataContext dataContext) : IFileRepository
{
    public async Task<DbFileModel> Add(DbFileModel model)
    {
        model.Id = Guid.NewGuid();

        return await dataContext.InsertAsync<DbFileModel>(Files.Insert, model);
    }

    public async Task<DbFileModel> Update(DbFileModel model)
    {
        return await dataContext.UpdateAsync<DbFileModel>(Files.Update, model);
    }

    public async Task<bool> Delete(Guid id)
    {
        return await dataContext.DeleteAsync(Files.Delete, new {id});
    }

    public async Task<IEnumerable<DbFileModel>> GetByIds(IEnumerable<Guid> ids)
    {
        return await dataContext.EnumerableOrEmptyAsync<DbFileModel>(Files.GetByIds, new {ids});
    }


    public async Task<IEnumerable<DbFileModel>> GetByUserIds(List<Guid> userIds)
    {
        return await dataContext.EnumerableOrEmptyAsync<DbFileModel>(Files.GetAllByLifeSpheres, new {userIds});
    }

    public async Task<IEnumerable<DbFileModel>> GetByContainerIds(List<Guid> containerIds)
    {
        return await dataContext.EnumerableOrEmptyAsync<DbFileModel>(Files.GetAllByLifeSpheres, new {containerIds});
    }
}