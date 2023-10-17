using System.Text.Json.Serialization;
using Demo.Web.Models.Dto;

public class DeploymentDto : BaseDto
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    [JsonPropertyName("source")]
    public string? Source { get; set; }
}