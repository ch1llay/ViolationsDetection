using System.Data;
using System.Reflection;
using AutoMapper.Internal;
using FluentMigrator.Builders.Create.Table;

namespace DataAccess.MigrationsHelpers;

internal interface ICreateTableCommon : ICreateTableWithColumnOrSchemaOrDescriptionSyntax, ICreateTableColumnOptionOrForeignKeyCascadeOrWithColumnSyntax { }

public static class TablesGenerator
{
    public static ICreateTableColumnOptionOrForeignKeyCascadeOrWithColumnSyntax? AddColumns(this ICreateTableWithColumnOrSchemaOrDescriptionSyntax table, Type type)
    {
        ICreateTableColumnOptionOrForeignKeyCascadeOrWithColumnSyntax? modifyTable = null;

        var properties = type.GetProperties();

        for (var i = 0; i < properties.Length; i++)
        {
            var field = properties[i];

            if (i == 0)
            {
                modifyTable = table.AddColumn(field);
            }
            else
            {
                modifyTable = modifyTable?.AddColumn(field);
            }
        }

        return modifyTable;
    }

    private static ICreateTableColumnOptionOrForeignKeyCascadeOrWithColumnSyntax AddColumn(this ICreateTableWithColumnSyntax table,
        PropertyInfo field)
    {
        var name = field.Name;
        var columnType = field.PropertyType;
        var columnKeyAttribute = Attribute.GetCustomAttributes(field).OfType<ColumnKeyAttribute>().FirstOrDefault();
        ICreateTableColumnOptionOrForeignKeyCascadeOrWithColumnSyntax res = null;

        switch (columnKeyAttribute)
        {
            case PrimaryKeyAttribute:
                res = (ICreateTableColumnOptionOrForeignKeyCascadeOrWithColumnSyntax)table.WithColumn(name).AsType(columnType).PrimaryKey();

                break;

            case ForeignKeyAttribute attribute:
                res = table.WithColumn(name).AsType(columnType).ForeignKey(attribute.ReferenceTableName, attribute.ReferenceTableColumnName);

                if (attribute is {DeleteCascade: true})
                {
                    res = res.OnDelete(Rule.Cascade);
                }

                break;

            default:
                res = (ICreateTableColumnOptionOrForeignKeyCascadeOrWithColumnSyntax)table.WithColumn(name).AsType(columnType);

                break;
        }

        if (columnKeyAttribute is {IsUniq: true})
        {
            res.Unique();
        }

        if (columnType.IsNullableType())
        {
            res = (ICreateTableColumnOptionOrForeignKeyCascadeOrWithColumnSyntax)res.Nullable();
        }

        return res;
    }

    private static ICreateTableColumnOptionOrWithColumnSyntax AsType(this ICreateTableColumnAsTypeSyntax column, Type type)
    {
        ICreateTableColumnOptionOrWithColumnSyntax? res = null;

        if (type == typeof(int))
        {
            res = column.AsInt32();
        }

        else if (type == typeof(float))
        {
            res = column.AsFloat();
        }

        else if (type == typeof(double))
        {
            res = column.AsDouble();
        }

        else if (type == typeof(decimal))
        {
            res = column.AsDecimal();
        }

        else if (type == typeof(Guid))
        {
            res = column.AsGuid();
        }

        else if (type == typeof(string))
        {
            res = column.AsString();
        }

        else if (type == typeof(byte[]))
        {
            res = column.AsBinary();
        }

        else if (type == typeof(bool))
        {
            res = column.AsBoolean();
        }

        else if (type == typeof(DateTime))
        {
            res = column.AsDateTime();
        }

        else
        {
            res = column.AsString();
        }

        if (type.IsNullableType())
        {
            res = res.Nullable();
        }

        return res;
    }
}
