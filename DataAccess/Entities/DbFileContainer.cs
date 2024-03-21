using DataAccess.MIgrationsHelpers;

namespace DataAccess.Entities;

[TableOrder(2)]
public class DbFileContainer
{
    [PrimaryKey] public Guid Id { get; set; }

    [ForeignKey(nameof(DbViolation), nameof(DbViolation.Id))]
    public Guid ViolationId { get; set; }
}