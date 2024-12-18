using System.Text.Json.Serialization;

namespace APITests.Models.Body;

public class Filter
{
    [JsonPropertyName("value")]
    public string ?Value { get; set; }
    [JsonPropertyName("name")]
    public string ?Name { get; set; }
}