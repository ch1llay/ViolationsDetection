using DataAccess.MIgrationsHelpers;

namespace DataAccess.Entities;

[TableOrder(4)]
public class DbViolationFile
{
    [PrimaryKey] public Guid Id { get; set; }

    [ForeignKey(nameof(DbViolation), nameof(DbViolation.Id))]
    public Guid ViolationId { get; set; }
    [ForeignKey(nameof(DbFile), nameof(DbFile.Id))]
    public Guid FileId { get; set; }
    public bool WithDetect { get; set; }
}