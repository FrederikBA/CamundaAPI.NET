using System.Net.Http.Headers;
using System.Text;

namespace Demo.Web.Services;

public class DeployService
{
    public async Task Deploy()
    {
        const string url = "http://localhost:8080/engine-rest/deployment/create";

        var file = File.ReadAllBytes("C:\\Users\\jason\\Desktop\\Demo\\Demo\\Demo.Bpmn\\Demo.Bpmn.bpmn");
        var multipartFormDataContent = new MultipartFormDataContent();
        var byteArrayContent = new ByteArrayContent(file);
        byteArrayContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
        multipartFormDataContent.Add(byteArrayContent, "data", "Demo.Bpmn.bpmn");

        var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes("demo:demo")));
        await httpClient.PostAsync(url, multipartFormDataContent);

    }
}