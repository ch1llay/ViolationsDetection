﻿using DataAccess.MIgrationsHelpers;

namespace DataAccess.Entities.Files;

public class DbFileContainer
{
    [ColumnKey] public Guid Id { get; set; }
    public Guid ViolationId { get; set; }
}