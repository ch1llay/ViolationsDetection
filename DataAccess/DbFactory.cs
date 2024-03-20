using System.Data.Common;
using System.Reflection;
using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace DataAccess;

public class DbFactory
{
    public delegate DbConnection ConnectionMethod();

    public static Action<IMigrationRunnerBuilder> GetMigrationSetuper(IConfiguration config, IMigrationRunnerBuilder runner)
    {
        var provider = Enum.Parse<DbProvider>(config["DbProvider"]);

        switch (provider)
        {
            case DbProvider.Mssql:
                return _ =>
                {
                    runner.AddSqlServer()
                        .WithGlobalConnectionString(config["MSConnection"] ?? throw new Exception("ms connection is not exist in config"))
                        .ScanIn(Assembly.GetExecutingAssembly()).For.All();
                };

            case DbProvider.Pgsql:
                return _ =>
                {
                    runner.AddPostgres()
                        .WithGlobalConnectionString(config["PGConnection"] ?? throw new Exception("pg connection is not exist in config"))
                        .ScanIn(Assembly.GetExecutingAssembly()).For.All();
                };

            default:
                throw new NotImplementedException();
        }
    }

    public static (ConnectionMethod, string) GetDbSettings(IConfiguration config)
    {
        var provider = Enum.Parse<DbProvider>(config["DbProvider"]);

        switch (provider)
        {
            case DbProvider.Mssql:
                return (
                    () => { return null; }, "output insert.");

            case DbProvider.Pgsql:
                return (() =>
                {
                    var con = new NpgsqlConnection(config["PgConnection"] ?? throw new Exception("pg connection is not exist in config"));
                    con.Open();

                    return con;
                }, "returning ");

            default:
                throw new NotImplementedException();
        }
    }
}
