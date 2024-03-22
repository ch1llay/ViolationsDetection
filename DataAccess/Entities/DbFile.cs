using DataAccess.MIgrationsHelpers;

namespace DataAccess.Entities;

[TableOrder(3)]
public class DbFile
{
    [PrimaryKey]public Guid Id { get; set; }
    
    public Guid UserId { get; set; }

    [ForeignKey(nameof(DbFileContainer), nameof(DbFileContainer.Id))]
    public Guid? FileContainerId { get; set; }

    public string Filename { get; set; }
    public string ContentType { get; set; }
    public DateTime CreatedDate { get; set; }
}