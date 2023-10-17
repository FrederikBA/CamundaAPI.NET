using System.Net.Http.Headers;
using System.Text;

namespace Demo.Web.Services;

public class DeployService
{
    private readonly HttpClient _httpClient;

    public DeployService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<string> Deploy()
    {
        const string url = "http://localhost:8080/engine-rest/deployment/create";
        
        var file = File.ReadAllBytes(GetFilePath());
        var multipartFormDataContent = new MultipartFormDataContent();
        var byteArrayContent = new ByteArrayContent(file);
        byteArrayContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
        multipartFormDataContent.Add(byteArrayContent, "data", "Demo.Bpmn.bpmn");

        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        _httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes("demo:demo")));
        var response = await _httpClient.PostAsync(url, multipartFormDataContent);
        var content = await response.Content.ReadAsStringAsync();
        return content;
    }

    private string GetFilePath()
    {
        var currentDirectory = Directory.GetCurrentDirectory();
        var path = Path.Combine(currentDirectory, "Resources", "ApiDemo.bpmn");
        return path;
    }
}