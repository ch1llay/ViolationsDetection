using DataAccess.DataContexts.Interfaces;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using DataAccess.Sql.Violations;

namespace DataAccess.Repositories;

public class ViolationRepository(IDataContext dataContext) : IViolationRepository
{
    public async Task<DbViolation> Add(DbViolation model)
    {
        model.Id = Guid.NewGuid();

        return await dataContext.InsertAsync<DbViolation>(Violations.Insert, model);
    }

    public async Task<DbViolation> Update(DbViolation model)
    {
        return await dataContext.UpdateAsync<DbViolation>(Violations.Update, model);
    }

    public async Task<bool> Delete(Guid id)
    {
        return await dataContext.DeleteAsync(Violations.Delete, new {id});
    }

    public async Task<IEnumerable<DbViolation>> GetByIds(IEnumerable<Guid> ids)
    {
        return await dataContext.EnumerableOrEmptyAsync<DbViolation>(Violations.GetByIds, new {ids});
    }

    public async Task<IEnumerable<DbViolation>> GetByUserId(List<Guid> userIds)
    {
        return await dataContext.EnumerableOrEmptyAsync<DbViolation>(Violations.GetAllByLifeSpheres, new {userIds});
    }
}