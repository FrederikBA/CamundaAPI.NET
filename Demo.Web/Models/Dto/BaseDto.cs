using System.Text.Json.Serialization;

namespace Demo.Web.Models.Dto;

public class BaseDto
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }
}