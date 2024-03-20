using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities.Files;

public class DbFileLink
{
    [Key] public Guid Id { get; set; }
    public Guid FileInfoId { get; set; }
    public DateTime CreatedDate { get; set; }
}