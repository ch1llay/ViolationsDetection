using DataAccess.MIgrationsHelpers;

namespace DataAccess.Entities;

public class DbFileContainer
{
    [ColumnKey] public Guid Id { get; set; }

    [ForeignKey(nameof(DbViolation), nameof(DbViolation.Id))]
    public Guid ViolationId { get; set; }
}