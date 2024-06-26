﻿using System.Text.Json.Serialization;

namespace Services.Models;

public class FileModel
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Filename { get; set; }
    public DateTime CreatedDate { get; set; }
    public string ContentType { get; set; }
    [JsonIgnore]
    public byte[] Content { get; set; }
}