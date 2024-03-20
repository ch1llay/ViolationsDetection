using DataAccess.MIgrationsHelpers;

namespace Services.Models.Files;

public class FileContent
{
    [ColumnKey] public Guid Id { get; set; }
    public Guid FileInfoId { get; set; }
    public byte[] Content { get; set; }
}