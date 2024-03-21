using Common.Enums;
using DataAccess.MIgrationsHelpers;

namespace DataAccess.Entities;

public class DbViolation
{
    [ColumnKey] public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Address { get; set; }
    public ViolationType ViolationType { get; set; }
    public DateTime EventDate { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Comment { get; set; }
    public ViolationStatus ViolationStatus { get; set; }
}