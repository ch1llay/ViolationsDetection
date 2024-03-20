using DataAccess.MIgrationsHelpers;

namespace Services.Models.Files;

public class FileContainer
{
    [ColumnKey] public Guid Id { get; set; }
    public Guid ViolationId { get; set; }
    public List<FileInfo> Files { get; set; }
}