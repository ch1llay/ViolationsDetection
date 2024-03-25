using Common.Enums;

namespace Services.Interactions.Models;

public class RecognitionResp
{
    public List<ViolationType> ViolationTypes { get; set; } = new List<ViolationType>();
    public string Base64Content { get; set; } 
}