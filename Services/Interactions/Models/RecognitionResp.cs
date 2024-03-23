using Common.Enums;

namespace Services.Interactions.Models;

public class RecognitionResp
{
    public ViolationType ViolationType { get; set; }
    public ByteArrayContent Content { get; set; }
}