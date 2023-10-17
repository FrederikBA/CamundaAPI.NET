using System.Text.Json.Serialization;

namespace Demo.Web.Models.Dto;

public class StartProcessDto
{
    [JsonPropertyName("processKey")]
    public string? ProcessKey { get; set; }
}