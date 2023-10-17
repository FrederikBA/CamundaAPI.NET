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

    public async Task<string> StartCamundaProcess(string processKey)
    {
        var url = $"http://localhost:8080/engine-rest/process-definition/key/{processKey}/start";
        var dto = new ProcessDto();
        var json = JsonSerializer.Serialize(dto);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync(url, content);

        return response.IsSuccessStatusCode ? "Process started successfully." : "Process failed to start.";
    }
}