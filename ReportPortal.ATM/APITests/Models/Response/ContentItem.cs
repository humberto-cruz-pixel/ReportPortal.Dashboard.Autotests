using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace APITests.Models.Response;

public class ContentItem
{
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("owner")]
    public string? Owner { get; set; }

    [JsonPropertyName("id")]
    public int? Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("widgets")]
    public List<Widget>? Widgets { get; set; }

    [JsonPropertyName("errorCode")]
    public int? ErrorCode { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }
}