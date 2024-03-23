using System.Data;
using Dapper;
using DataAccess.DataContexts.Interfaces;
using Microsoft.Extensions.Configuration;

namespace DataAccess.DataContexts;

public class DapperContext : IDataContext
{
    private readonly DbFactory.ConnectionMethod _connectionMethod;
    private readonly string _returningKeyword;

    public DapperContext(IConfiguration config)
    {
        var dbSettings = DbFactory.GetDbSettings(config);
        _connectionMethod = dbSettings.Item1;
        _returningKeyword = dbSettings.Item2;
    }

    public async Task<T> InsertAsync<T>(string script, object param)
    {
        script = PrepareInsertQuery(script);
        await using var db = _connectionMethod();

        return await db.QueryFirstOrDefaultAsync<T>(script, param);
    }

    public async Task<IEnumerable<Guid>> InsertManyAsync<T>(string script, IEnumerable<T> objects)
    {
        script = PrepareInsertQuery(script);
        await using var db = _connectionMethod();
        using IDbTransaction transaction = await db.BeginTransactionAsync();
        var insertedObjectsIds = new List<Guid>();

        foreach (var item in objects)
        {
            var id = await db.ExecuteScalarAsync<Guid>(script, item, transaction);
            insertedObjectsIds.Add(id);
        }

        transaction.Commit();

        return insertedObjectsIds;
    }

    public async Task<T?> FirstOrDefaultAsync<T>(string script, object param)
    {
        await using var db = _connectionMethod();

        return await db.QueryFirstOrDefaultAsync<T>(script, param);
    }

    public async Task<IEnumerable<T>> EnumerableOrEmptyAsync<T>(string script, object param)
    {
        await using var db = _connectionMethod();

        return await db.QueryAsync<T>(script, param);
    }

    public async Task<bool> DeleteAsync(string script, object param)
    {
        await using var db = _connectionMethod();

        return await db.ExecuteAsync(script, param) > 0;
    }

    public async Task<long> DeleteManyAsync(string script, object param)
    {
        await using var db = _connectionMethod();

        return await db.ExecuteAsync(script, param);
    }

    public async Task<T> UpdateAsync<T>(string script, object param)
    {
        await using var db = _connectionMethod();

        return await db.QueryFirstOrDefaultAsync<T>(script, param);
    }

    public async Task<IEnumerable<T>> UpdateManyAsync<T>(string script, object param)
    {
        await using var db = _connectionMethod();

        return await db.QueryAsync<T>(script, param);
    }

    private string PrepareInsertQuery(string query)
    {
        return string.Format(query, _returningKeyword);
    }
}