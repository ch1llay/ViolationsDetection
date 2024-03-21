using DataAccess.MIgrationsHelpers;

namespace DataAccess.Entities;

public class DbFileModel
{
    [ColumnKey] public Guid Id { get; set; }
    public Guid UserId { get; set; }

    [ForeignKey(nameof(DbFileContainer), nameof(DbFileContainer.Id))]
    public Guid? FileContainerId { get; set; }

    public string Filename { get; set; }
    public DateTime CreatedDate { get; set; }
    public byte[] Content { get; set; }
}