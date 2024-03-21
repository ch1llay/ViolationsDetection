using DataAccess.MIgrationsHelpers;

namespace DataAccess.Entities;

public class DbFileContainer
{
    [ColumnKey] public Guid Id { get; set; }
    public Guid ViolationId { get; set; }
}