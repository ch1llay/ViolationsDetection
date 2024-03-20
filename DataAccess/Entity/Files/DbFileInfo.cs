﻿using DataAccess.MigrationsHelpers;

namespace DataAccess.Entity.Files;

public class DbFileInfo
{
    [ColumnKey] public Guid Id { get; set; }
    public Guid UserId { get; set; }
    [ForeignKey("","")] public Guid FileContainerId { get; set; }
    public string Filename { get; set; }
    public DateTime CreatedDate { get; set; }
}