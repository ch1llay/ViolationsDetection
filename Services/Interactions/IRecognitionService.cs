using Services.Interactions.Models;
using Services.Models;

namespace Services.Interactions;

public interface IRecognitionService
{
    public Task<RecognitionResp?> Recognize(FileModel fileModel, string token);
}