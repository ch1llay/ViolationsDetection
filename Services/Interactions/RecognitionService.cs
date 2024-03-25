using System.Net.Http.Headers;
using Common.Extensions;
using Microsoft.Extensions.Configuration;
using Services.Interactions.Models;
using Services.Models;

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

    public async Task<RecognitionResp?> Recognize(FileModel fileModel, string token)
    {
        try
        {
            using (var httpClient = new HttpClient())
            {
                using (var content = new MultipartFormDataContent())
                {
                    var fileContent = new ByteArrayContent(fileModel.Content);
                    fileContent.Headers.ContentType = new MediaTypeHeaderValue(fileModel.ContentType);
                    content.Add(fileContent, name:"file", fileName:fileModel.Filename);
                    var resp = await httpClient.PostAsync($"{recognitionServiceUrl}/detect?token={token}", content);
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

//ssh -i C:/users/smartway.today/.ssh/id_rsa -p 36921 hack@inkve.dedyn.io

// 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
// 1956955