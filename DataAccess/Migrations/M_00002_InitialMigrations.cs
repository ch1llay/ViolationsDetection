using System.Reflection;
using Common.Extensions;
using DataAccess.Entity;
using FluentMigrator;
using FluentMigrator.Expressions;

namespace DataAccess.Migrations;

[Migration(2, "Initial1")]
public class M_00002_InitialMigrations : Migration
{
    public override void Up()
    {
        //Alter.Table(nameof(DbActionDirectionFromLifeSphere)).AlterColumn(nameof(DbActionDirectionFromLifeSphere.ParentActionDirectionId)).AsGuid().Nullable();

    }

    public override void Down()
    {
    }
}
