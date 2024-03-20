﻿namespace DataAccess.MigrationsHelpers;

public class TableOrderAttribute : Attribute
{
    public TableOrderAttribute(int order)
    {
        Order = order;
    }

    public int Order { get; set; }
}
