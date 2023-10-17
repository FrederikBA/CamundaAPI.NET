using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
namespace Demo.Web.Services;

public class DeployService
{
    private readonly HttpClient _httpClient;

    public DeployService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<string> Deploy(string deploymentName)
    {
        const string url = "http://localhost:8080/engine-rest/deployment/create";
        
        var file = await File.ReadAllBytesAsync(GetFilePath());
        var multipartFormDataContent = new MultipartFormDataContent();
        var byteArrayContent = new ByteArrayContent(file);
        byteArrayContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
        multipartFormDataContent.Add(byteArrayContent, "data", "ApiDemo.bpmn");
        multipartFormDataContent.Add(new StringContent(deploymentName), "deployment-name");
        multipartFormDataContent.Add(new StringContent(".NET Application"), "deployment-source");

        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        _httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes("demo:demo")));
        var response = await _httpClient.PostAsync(url, multipartFormDataContent);
        var result = await response.Content.ReadAsStringAsync();
        return result;
    }

    public async Task<string> DeleteDeployment(string id)
    {
        var url = $"http://localhost:8080/engine-rest/deployment/{id}?cascade=true";
        var response = await _httpClient.DeleteAsync(url);
        var result = await response.Content.ReadAsStringAsync();
        return result;
    }
    
    public async Task<List<DeploymentDto>> GetDeployments()
    {
        var url = "http://localhost:8080/engine-rest/deployment";
        var response = await _httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync();
            var deployments = JsonSerializer.Deserialize<List<DeploymentDto>>(result);
            return deployments;
        }
        else
        {
            return new List<DeploymentDto>();
        }
    }

    
    
    
    private string GetFilePath()
    {
        var currentDirectory = Directory.GetCurrentDirectory();
        var path = Path.Combine(currentDirectory, "Resources", "ApiDemo.bpmn");
        return path;
    }
}