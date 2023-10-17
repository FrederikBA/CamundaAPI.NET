namespace Demo.Web.Services;

public class TaskService
{
    private readonly HttpClient _httpClient;
    
    public TaskService()
    {
        _httpClient = new HttpClient();
    }
}