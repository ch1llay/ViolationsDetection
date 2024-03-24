using System.Net.Http.Headers;
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
        recognitionServiceUrl = _configuration.GetSection("Services")["RecognitionServiceUrl"] ?? string.Empty;
    }

    public async Task<RecognitionResp?> Recognize(RecognitionReque recognitionReque)
    {
        try
        {
            using (var httpClient = new HttpClient())
            {
                using (var content = new MultipartFormDataContent())
                {
                    content.Add(recognitionReque.Content, name:"file", fileName:"filename123.jpg");
                    var resp = await httpClient.PostAsync($"{recognitionServiceUrl}/files", content);
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