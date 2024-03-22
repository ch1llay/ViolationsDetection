namespace Services.Models;

public class FileModel
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid? FileContainerId { get; set; }
    public string Filename { get; set; }
    public DateTime CreatedDate { get; set; }
    public string ContentType { get; set; }
    public FileContent Content { get; set; }
}