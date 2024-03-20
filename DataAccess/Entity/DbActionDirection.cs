using DataAccess.MIgrationsHelpers;

namespace DataAccess.Entity;

[TableOrder(2)]
public class DbActionDirection
{
    [PrimaryKey] public Guid Id { get; set; }

    //[ForeignKey(nameof(DbLifeSphere), nameof(DbLifeSphere.Id))]
    public Guid LifeSphereId { get; set; }

    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
}
