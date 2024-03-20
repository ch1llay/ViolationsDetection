using DataAccess.MIgrationsHelpers;

namespace Services.Models.Files;

public class FileInfo
{
    [ColumnKey] public Guid Id { get; set; }
    public Guid UserId { get; set; }
    [ForeignKey("","")] public Guid FileContainerId { get; set; }
    public string Filename { get; set; }
    public DateTime CreatedDate { get; set; }
    public FileContent FileContent { get; set; }
}