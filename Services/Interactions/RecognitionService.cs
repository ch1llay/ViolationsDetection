using Common.Extensions;
using Microsoft.Extensions.Configuration;
using Services.Interactions.Models;

namespace Services.Interactions;

public class RecognitionService : IRecognitionService
{
    private readonly string recognitionServiceUrl;
    private readonly IConfiguration _configuration;

    public RecognitionService(IConfiguration configuration)
    {
        _configuration = configuration;
        recognitionServiceUrl = _configuration.GetSection("")[""];
    }

    public async Task<RecognitionResp?> Recognize(RecognitionReque recognitionReque)
    {
        try
        {
            using (var httpClient = new HttpClient())
            {
                using (var content = new MultipartFormDataContent())
                {
                    content.Add(recognitionReque.Content);
                    var resp = await httpClient.PostAsync($"{recognitionServiceUrl}/detect", content);
                    var respContent = await resp.Content.ReadAsStringAsync();

                    return respContent.FromJson<RecognitionResp>();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);

            return null;
        }
    }
}