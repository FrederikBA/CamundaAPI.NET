using System.Text;
using System.Text.Json;
using Demo.Web.Models.Dto;

namespace Demo.Web.Services;

public class ProcessService
{
    private readonly HttpClient _httpClient;

    public ProcessService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<string> StartCamundaProcess()
    {
        var dto = new ProcessDTO();
        var json = JsonSerializer.Serialize(dto);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        
        var response = await _httpClient.PostAsync(GetProcessUrl("ApiDemo"), content);
        var result = await response.Content.ReadAsStringAsync();
        return result;
    }

    private string GetProcessUrl(string key)
    {
        var url = $"http://localhost:8080/engine-rest/process-definition/key/{key}/start";
        return url;
    }
}