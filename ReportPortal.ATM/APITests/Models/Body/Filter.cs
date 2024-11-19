using System.Text.Json.Serialization;

public class Filter
{
    [JsonPropertyName("value")]
    public string Value { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
}