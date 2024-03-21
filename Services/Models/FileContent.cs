namespace Services.Models;

public class FileContent
{
    public Guid Id { get; set; }
    public Guid? FileContainerId { get; set; }
    public byte[] Content { get; set; }
}