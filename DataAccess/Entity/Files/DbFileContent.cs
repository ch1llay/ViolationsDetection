using DataAccess.MigrationsHelpers;

namespace DataAccess.Entity.Files;

public class DbFileContent
{
    [ColumnKey] public Guid Id { get; set; }
    public Guid FileInfoId { get; set; }
    public byte[] Content { get; set; }
}