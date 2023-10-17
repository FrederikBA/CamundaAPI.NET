using System.Text.Json.Serialization;

namespace Demo.Web.Models.Dto;

public class ProcessDto
{
    [JsonPropertyName("processKey")]
    public string ProcessKey { get; set; }
    
    public ProcessDto()
    {
    }
}