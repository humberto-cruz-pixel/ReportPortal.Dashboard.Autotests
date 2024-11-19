using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace APITests.Models.Response;

public class Response
{
    [JsonPropertyName("id")]
    public int? Id { get; set; }

    [JsonPropertyName("content")]
    public List<ContentItem>? Content { get; set; }

    [JsonPropertyName("page")]
    public PageInfo? Page { get; set; }

    [JsonPropertyName("errorCode")]
    public int? ErrorCode { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }
}