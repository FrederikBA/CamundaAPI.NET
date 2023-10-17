using System.Text.Json.Serialization;

namespace Demo.Web.Models.Dto;

public class ProcessDto : BaseDto
{
    [JsonPropertyName("ended")]
    public bool? Ended { get; set; }
}