﻿using DataAccess.DataContexts.Interfaces;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using DataAccess.Sql.FileContainers;

namespace DataAccess.Repositories;

public class FileContainerRepository(IDataContext dataContext) : IFileContainerRepository
{
    public async Task<DbFileContainer> Add(DbFileContainer model)
    {
        model.Id = Guid.NewGuid();

        return await dataContext.InsertAsync<DbFileContainer>(FileContainers.Insert, model);
    }

    public async Task<DbFileContainer> Update(DbFileContainer model)
    {
        return await dataContext.UpdateAsync<DbFileContainer>(FileContainers.Update, model);
    }

    public async Task<bool> Delete(Guid id)
    {
        return await dataContext.DeleteAsync(FileContainers.Delete, new {id});
    }

    public async Task<IEnumerable<DbFileContainer>> GetByIds(IEnumerable<Guid> ids)
    {
        return await dataContext.EnumerableOrEmptyAsync<DbFileContainer>(FileContainers.GetByIds, new {ids});
    }

    public async Task<IEnumerable<DbFileContainer>> GetByViolationIds(List<Guid> violationIds)
    {
        return await dataContext.EnumerableOrEmptyAsync<DbFileContainer>(FileContainers.GetByIds, new {violationIds});
    }
}