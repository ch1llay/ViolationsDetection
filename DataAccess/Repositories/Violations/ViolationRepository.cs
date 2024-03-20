using DataAccess.DataContexts.Interfaces;
using DataAccess.Entities.Violations;
using DataAccess.Repositories.Violations.Interfaces;
using DataAccess.Sql.ActionDirections;

namespace DataAccess.Repositories.Violations;

public class ViolationRepository(IDataContext dataContext) : IViolationRepository
{
    public async Task<DbViolation> Add(DbViolation model)
    {
        model.Id = Guid.NewGuid();

        return await dataContext.InsertAsync<DbViolation>(ActionDirections.Insert, model);
    }

    public async Task<DbViolation> Update(DbViolation model)
    {
        return await dataContext.UpdateAsync<DbViolation>(ActionDirections.Update, model);
    }

    public async Task<bool> Delete(Guid id)
    {
        return await dataContext.DeleteAsync(ActionDirections.Delete, new {id});
    }

    public async Task<IEnumerable<DbViolation>> GetByIds(IEnumerable<Guid> ids)
    {
        return await dataContext.EnumerableOrEmptyAsync<DbViolation>(ActionDirections.GetByIds, new {ids});
    }

    public async Task<IEnumerable<DbViolation>> GetByUserId(List<Guid> userIds)
    {
        return await dataContext.EnumerableOrEmptyAsync<DbViolation>(ActionDirections.GetAllByLifeSpheres, new {userIds});
    }
    
}
