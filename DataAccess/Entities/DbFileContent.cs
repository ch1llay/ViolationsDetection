using DataAccess.MIgrationsHelpers;

namespace DataAccess.Entities;

[TableOrder(4)]
public class DbFileContent
{
    [PrimaryKey] public Guid Id { get; set; }

    [ForeignKey(nameof(DbFile), nameof(DbFile.Id))]
    public Guid? FileContainerId { get; set; }

    public byte[] Content { get; set; }
}