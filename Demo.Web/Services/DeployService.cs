namespace Demo.Web.Services;

public class DeployService
{
    public async Task<string> Deploy()
    {
        const string url = "http://localhost:8080/engine-rest/engine";
        
        var httpClient = new HttpClient();
        var response = await httpClient.GetAsync(url);
        var result = await response.Content.ReadAsStringAsync();        
        return result;
    }
}