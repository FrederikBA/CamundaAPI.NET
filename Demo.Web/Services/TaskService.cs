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

        return tasks;
    }

    public async Task<TaskDto> GetTask(string id)
    {
        var url = $"http://localhost:8080/engine-rest/task/{id}";
        var response = await _httpClient.GetAsync(url);
        var result = await response.Content.ReadAsStringAsync();
        var task = JsonSerializer.Deserialize<TaskDto>(result);
        return task;
    }
}