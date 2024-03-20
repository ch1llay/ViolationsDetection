using DataAccess.MigrationsHelpers;

namespace DataAccess.Entity.Files;

public class FileContainer
{
    [ColumnKey] public Guid Id { get; set; }
    public Guid ViolationId { get; set; }
}