﻿using System.Reflection;
using Common.Extensions;
using DataAccess.MIgrationsHelpers;
using FluentMigrator;
using FluentMigrator.Expressions;

namespace DataAccess.Migrations;

[Migration(1, "Initial")]
public class M_00001_InitialMigrations : Migration
{
    public override void Up()
    {
        var name = nameof(DataAccess.Entities);
        var models = Assembly.GetExecutingAssembly()
            .GetTypesInNamespace("DataAccess.Entities");
        var sortingModels = models
            .OrderBy(t => Attribute.GetCustomAttributes(t)
                .OfType<TableOrderAttribute>().FirstOrDefault()?.Order).ToList();
foreach (var model in sortingModels)
        {
            Create.Table(model.Name).AddColumns(model);
        }
    }

    public override void Down()
    {
        var name = nameof(DataAccess.Entities);
        var models = Assembly.GetExecutingAssembly()
            .GetTypesInNamespace("DataAccess.Entities");
        var sortingDescendingModels = models
            .OrderByDescending(t => Attribute.GetCustomAttributes(t)
                .OfType<TableOrderAttribute>().FirstOrDefault()?.Order).ToList();
foreach (var model in sortingDescendingModels)
        {
            Delete.Table(model.Name);
        }
    }
}
