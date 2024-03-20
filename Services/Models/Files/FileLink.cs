using System.ComponentModel.DataAnnotations;

namespace Services.Models.Files;

public class FileLink
{
    [Key] public Guid Id { get; set; }
    public Guid FileInfoId { get; set; }
    public DateTime CreatedDate { get; set; }
}