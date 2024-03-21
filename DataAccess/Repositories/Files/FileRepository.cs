using DataAccess.DataContexts.Interfaces;
using DataAccess.Entities.Files;
using DataAccess.Repositories.Files.Interfaces;
using DataAccess.Sql.ActionDirections;

namespace DataAccess.Repositories.Files;

public class FileRepository(IDataContext dataContext) : IFileRepository
{
    public async Task<DbFileModel> Add(DbFileModel model)
    {
        model.Id = Guid.NewGuid();

        return await dataContext.InsertAsync<DbFileModel>(ActionDirections.Insert, model);
    }

    public async Task<DbFileModel> Update(DbFileModel model)
    {
        return await dataContext.UpdateAsync<DbFileModel>(ActionDirections.Update, model);
    }

    public async Task<bool> Delete(Guid id)
    {
        return await dataContext.DeleteAsync(ActionDirections.Delete, new {id});
    }

    public async Task<IEnumerable<DbFileModel>> GetByIds(IEnumerable<Guid> ids)
    {
        return await dataContext.EnumerableOrEmptyAsync<DbFileModel>(ActionDirections.GetByIds, new {ids});
    }


    public async Task<IEnumerable<DbFileModel>> GetByUserIds(List<Guid> userIds)
    {
        return await dataContext.EnumerableOrEmptyAsync<DbFileModel>(ActionDirections.GetAllByLifeSpheres, new {userIds});
    }

    public async Task<IEnumerable<DbFileModel>> GetByContainerIds(List<Guid> containerIds)
    {
        return await dataContext.EnumerableOrEmptyAsync<DbFileModel>(ActionDirections.GetAllByLifeSpheres, new {containerIds});
    }
}