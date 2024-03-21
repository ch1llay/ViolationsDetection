namespace Services.Models;

public class FileContainer
{
    public Guid Id { get; set; }
    public Guid ViolationId { get; set; }
    public List<FileModel> Files { get; set; }
}