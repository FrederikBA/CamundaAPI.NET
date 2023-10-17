using System.Text.Json.Serialization;

namespace Demo.Web.Models.Dto;

public class TaskDto : BaseDto
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }
}