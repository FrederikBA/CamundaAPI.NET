using System.Text;
using System.Text.Json;
using Demo.Web.Models.Dto;

namespace Demo.Web.Services;

public class TaskService
{
    private readonly HttpClient _httpClient;

    public TaskService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<List<TaskDto>> GetTasks()
    {
        var url = $"http://localhost:8080/engine-rest/task";
        var response = await _httpClient.GetAsync(url);
        var result = await response.Content.ReadAsStringAsync();
        var tasks = JsonSerializer.Deserialize<List<TaskDto>>(result);

        return tasks ?? throw new InvalidOperationException();
    }

    public async Task<TaskDto> GetTask(string id)
    {
        var url = $"http://localhost:8080/engine-rest/task/{id}";
        var response = await _httpClient.GetAsync(url);
        var result = await response.Content.ReadAsStringAsync();
        var task = JsonSerializer.Deserialize<TaskDto>(result);
        return task ?? throw new InvalidOperationException();
    }

    public async Task CompletePickTeamTask(string id, CompleteTaskDto dto)
    {
        var url = $"http://localhost:8080/engine-rest/task/{id}/complete";
        var dtoJson = JsonSerializer.Serialize(dto);
        var content = new StringContent(dtoJson, Encoding.UTF8, "application/json");
        await _httpClient.PostAsync(url, content);
    }

    public async Task CompleteWatchGameTask(string id)
    {
        var url = $"http://localhost:8080/engine-rest/task/{id}/complete";
        await _httpClient.PostAsync(url, null);
    }
}