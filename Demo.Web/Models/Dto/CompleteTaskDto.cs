using System.Text.Json.Serialization;

public class CompleteTaskDto
{
    [JsonPropertyName("variables")]
    public Dictionary<string, Dictionary<string, object>>? Variables { get; set; }
}