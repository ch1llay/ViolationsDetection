using Services.Interactions.Models;

namespace Services.Interactions;

public interface IRecognitionService
{
    public Task<RecognitionResp?> Recognize(RecognitionReque recognitionReque);
}